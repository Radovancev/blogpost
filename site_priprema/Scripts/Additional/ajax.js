$(document).ready(function () {

    var user = $('#user').val();
    

    

    $('#create').click(function () {

        
        
        var Comment = escape($('body .note-editable').html());
        var PostID = $('#postid').val();
        var key = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: "http://localhost:65393/Comment/Create" ,
            method: "POST",
            data: {
                Comment: Comment,
                PostID: PostID,
                __RequestVerificationToken:key
            },
            success(data) {
                upisiCom(data);
            },
            error(xhr, error) {
                console.log(error);
            }


        });
    });

    function upisiCom(data) {
        var podaci = data[0].Comment;
        var text = "";
        for (var i = 0; i < podaci.length; i++) {
            text += `<div class="title">
                <div class="clearfix"></div>
                <div class="tilte-grid">
                    <p class="Sed">
                        <span>
                            `+ unescape(podaci[i].Comment) + `
                        </span>
                    </p>
                </div>
                <div class="kreator">
                    <p>Created by: <a href="#">`+ user + `</a><span>` + podaci[i].Created_At +`</span></p>
                </div>
                <div class="clearfix"></div>
            </div>`;
        }
            $('.comments').html(text);
    }
    
});