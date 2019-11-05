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

$(document).ready(function(){
    $("#submit").click(function(){
    var title = $('#Title').val();
    var director = $('#Director').val();
    var genre = $('#Genre').val();
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44352/api/movie',
        dataType: 'json',
        data: json.stringify([title, director, genre]),
        success: function(movie) { },
        error: function(xhr, textStatus, errorthrown) { alert('error'); },
        console.log(movie);
        });
    });
});