// Storage is optional: the language selector still works when it is blocked.
window.portfolioLanguage = {
    get() {
        try { return localStorage.getItem('portfolio.language'); } catch { return null; }
    },
    set(language, messages) {
        document.documentElement.lang = language;
        try { localStorage.setItem('portfolio.language', language); } catch { /* Private browsing. */ }
        if (messages) {
            const error = document.querySelector('[data-portfolio-error]');
            const reload = document.querySelector('[data-portfolio-reload]');
            const dismiss = document.querySelector('[data-portfolio-dismiss]');
            if (error) error.textContent = messages.error;
            if (reload) reload.textContent = messages.reload;
            if (dismiss) dismiss.setAttribute('aria-label', messages.dismiss);
        }
    }
};

// Keep explicit ARIA state in sync with native mouse and keyboard toggles.
document.addEventListener('toggle', event => {
    const details = event.target;
    if (details instanceof HTMLDetailsElement && details.matches('.project-card details')) {
        details.querySelector('summary').setAttribute('aria-expanded', String(details.open));
    }
}, true);

// Native dialog provides focus containment and Escape; keep scroll and focus restoration explicit.
window.portfolioGallery = (() => {
    const viewers = new WeakMap();
    function restore(state, focus = true) {
        state.gallery.classList.remove('is-viewing');
        if (state.lock) {
            document.documentElement.style.overflow = state.lock.htmlOverflow;
            document.documentElement.style.scrollbarGutter = state.lock.gutter;
            document.body.style.overflow = state.lock.bodyOverflow;
            state.lock = null;
        }
        if (focus && state.opener?.isConnected) state.opener.focus({ preventScroll: true });
    }
    return {
        init(dialog, reference) {
            if (viewers.has(dialog)) return;
            const state = { reference, opener: null, lock: null, gallery: dialog.closest('.screenshot-gallery') };
            state.onClose = () => restore(state);
            state.onKey = event => {
                if (event.key === 'Tab') {
                    const buttons = [...dialog.querySelectorAll('button:not([disabled])')];
                    const first = buttons[0], last = buttons[buttons.length - 1];
                    if (event.shiftKey && document.activeElement === first) {
                        event.preventDefault();
                        last.focus();
                    } else if (!event.shiftKey && document.activeElement === last) {
                        event.preventDefault();
                        first.focus();
                    }
                    return;
                }
                if (event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') return;
                event.preventDefault();
                state.reference.invokeMethodAsync('Navigate', event.key === 'ArrowLeft' ? -1 : 1);
            };
            state.onClick = event => {
                const rect = dialog.getBoundingClientRect();
                if (event.target === dialog && (event.clientX < rect.left || event.clientX > rect.right || event.clientY < rect.top || event.clientY > rect.bottom)) dialog.close();
            };
            dialog.addEventListener('close', state.onClose);
            dialog.addEventListener('keydown', state.onKey);
            dialog.addEventListener('click', state.onClick);
            viewers.set(dialog, state);
        },
        open(dialog, opener) {
            const state = viewers.get(dialog);
            if (!state || dialog.open) return;
            state.opener = opener;
            state.lock = {
                htmlOverflow: document.documentElement.style.overflow,
                bodyOverflow: document.body.style.overflow,
                gutter: document.documentElement.style.scrollbarGutter
            };
            document.documentElement.style.scrollbarGutter = 'stable';
            document.documentElement.style.overflow = 'hidden';
            document.body.style.overflow = 'hidden';
            dialog.showModal();
            state.gallery.classList.add('is-viewing');
            dialog.querySelector('[data-gallery-close]').focus({ preventScroll: true });
        },
        close(dialog) { if (dialog?.open) dialog.close(); },
        reveal(gallery, index) {
            const rail = gallery.querySelector('.gallery-thumbnails');
            const thumb = rail.querySelector(`[data-index="${index}"]`);
            if (!thumb) return;
            const railRect = rail.getBoundingClientRect();
            const thumbRect = thumb.getBoundingClientRect();
            rail.scrollLeft += thumbRect.left - railRect.left - (rail.clientWidth - thumbRect.width) / 2;
        },
        dispose(dialog) {
            const state = viewers.get(dialog);
            if (!state) return;
            if (dialog.open) dialog.close();
            restore(state, false);
            dialog.removeEventListener('close', state.onClose);
            dialog.removeEventListener('keydown', state.onKey);
            dialog.removeEventListener('click', state.onClick);
            viewers.delete(dialog);
        }
    };
})();
