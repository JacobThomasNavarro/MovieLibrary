(function($){
    function processForm( e ){
        var dict = {
            Title : this["title"].value,
            Director: this["director"].value,
            Genre: this["genre"].value,
        };

        $.ajax({
            url: 'https://localhost:44352/api/movie',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();
    }

    $('#my-form').submit( processForm );
})(jQuery);

$(document).ready(function(){
$('input').on('click', function () {
    var $movies = $('#movies');
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44352/api/movie',
        success: function(movies){
           $.each(movies, function(i, movie){
                $movies.html('');
                $movies.append('<li>Title: '+ movie.Title +' Director: '+ movie.Director +' Genre: '+ movie.Genre + '</li>'); 
            });
        }
    });
});
})
