const toggleBtn = document.querySelector('.menu-toggle');
const navLinks = document.querySelector('.nav-links');
const search = document.querySelector('.search-container');
const authBtn = document.querySelector('.btn-auth');

toggleBtn.addEventListener('click', () => {
	navLinks.classList.toggle('active');
	search.classList.toggle('active');
	authBtn.classList.toggle('active');
});