<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

$(document).ready(function () {
    $('.nav-link').click(function () {
        $('.nav-link').removeClass('active');
        $(this).addClass('active');
    });
});