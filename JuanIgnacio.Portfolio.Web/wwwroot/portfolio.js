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
