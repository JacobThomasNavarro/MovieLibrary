$(document).ready(function(){
$('input').on('click', function () {
    var $movies = $('#movies');
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44352/api/movie',
        success: function(movies){
           $.each(movies, function(i, movie){
                $movies.append('<li>Title: '+ movie.Title +' Director: '+ movie.Director +' Genre: '+ movie.Genre + '</li>');
            });
        }
    });
});
});

// ("button").click