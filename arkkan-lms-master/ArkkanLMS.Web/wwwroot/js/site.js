// ArkkanLMS — light client helpers
(function () {
  // Apply theme from cookie to <html> on first paint to avoid FOUC.
  try {
    var m = document.cookie.match(/(?:^|; )ark_theme=([^;]+)/);
    var theme = m ? decodeURIComponent(m[1]) : 'light';
    document.documentElement.setAttribute('data-theme', theme === 'dark' ? 'dark' : 'light');
  } catch (e) { /* ignore */ }

  // Mobile drawer toggle (admin/trainer)
  document.addEventListener('click', function (e) {
    var btn = e.target.closest('[data-drawer-toggle]');
    if (!btn) return;
    var sidebar = document.querySelector('.dashboard-sidebar');
    if (!sidebar) return;
    sidebar.classList.toggle('drawer-open');
    if (sidebar.classList.contains('drawer-open')) {
      Object.assign(sidebar.style, {
        position: 'fixed', top: '0', insetInlineStart: '0',
        width: 'min(320px, 80vw)', height: '100vh', zIndex: '2000',
        boxShadow: '0 30px 80px rgba(0,0,0,.35)'
      });
    } else {
      sidebar.removeAttribute('style');
    }
  });
})();
