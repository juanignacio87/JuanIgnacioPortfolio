// Storage is optional: the language selector still works when it is blocked.
window.portfolioLanguage = {
    get() {
        try { return localStorage.getItem('portfolio.language'); } catch { return null; }
    },
    set(language) {
        document.documentElement.lang = language;
        try { localStorage.setItem('portfolio.language', language); } catch { /* Private browsing. */ }
    }
};

// Keep explicit ARIA state in sync with native mouse and keyboard toggles.
document.addEventListener('toggle', event => {
    const details = event.target;
    if (details instanceof HTMLDetailsElement && details.matches('.project-card details')) {
        details.querySelector('summary').setAttribute('aria-expanded', String(details.open));
    }
}, true);
