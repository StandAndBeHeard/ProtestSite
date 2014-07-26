

function requireLogin(message)
{
    if (message == null) message = 'Please login first';
    if (!isAuthenticated) {
        alert(message);
        return false;
    }
    return true;
}

function isAuthenticated()
{
    return $('#logoutLink').length == 1;
}



function showWriteComments() {
    $('.commentHolder').each(function () { showWriteComment($(this)); });
}

function showWriteComment(holder) {
    var parentId = holder.data('parentid');
    var contentId = holder.data('contentid');
    var result = '<div><textarea id="comment' + parentId + '" class="form-control" placeholder="Add your comment" style=\"margin-bottom:10px;\"></textarea>' +
    '<button id="btnSubmitComment' + parentId.toString() + '" class="btn btn-sm btn-primary pull-right" data-contentid="' + contentId + '" data-parentid="' + parentId + '" onclick="checkPostComment(this);">Publish Comment</button></div>';
    holder.html(result);
}

function showReply(el) {
    if (!isAuthenticated()) alert('Please login first.');
    else {
        var button = $(el);
        var container = $(el.parentNode);
        if ($('.commentHolder[data-parentid="' + button.data('parentid') + '"]').length == 0) {
            var content = $('<div class="commentHolder" data-contentid="' + button.data('contentid') + '" data-parentid="' + button.data('parentid') + '"></div>');
            container.html(container.html() + '<br/><br/>');
            content.insertAfter(container);
            showWriteComment(content);
        }
    }
}

function checkPostComment(el) {
    if (isAuthenticated()) postComment(el); else alert('Please login first.');
}

function postComment(el) {
    var button = $(el);
    var contentId = button.data('contentid');
    var parentId = button.data('parentid');
    var body = $('#comment' + parentId).val();
    data = { contentType: 'protest', contentId: contentId, parentId: parentId, commentBody: body };
    $.post("/ajax/comment.aspx", data, function (response) {
        var data = $.parseJSON(response);
        if (data.errors != null) alert("Please correct the following problem(s):\n\n" + data.errors.join('\n'));
        else window.location.reload();
    });
}

$(function () {
    showWriteComments();
});