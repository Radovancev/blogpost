$(document).ready(function () {
	$("#readmore").click(function () {
		$(".readmore-panel").slideToggle();
		$(".readmore-panel").removeClass("skriven");
	})
});

function posaljimail() {
    window.open('mailto:test@example.com');
}