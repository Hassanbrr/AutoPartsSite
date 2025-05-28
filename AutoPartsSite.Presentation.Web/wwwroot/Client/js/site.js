const toggleBtn = document.querySelector('.menu-toggle');
const mobilePanel = document.getElementById('mobilePanel');
const closeBtn = document.getElementById('closeBtn');
// باز کردن منو (#6)
toggleBtn.addEventListener('click', () => {
    mobilePanel.classList.remove('inactive');
    mobilePanel.classList.add('active');
});
// بستن منو (#10)
closeBtn.addEventListener('click', () => {
    mobilePanel.classList.remove('active');
    mobilePanel.classList.add('inactive');
});