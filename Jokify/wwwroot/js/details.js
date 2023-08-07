    $(document).ready(function () {
        $(".cancel-button").on("click", function () {
            const commentId = $(this).closest(".edit-form").data("comment-id");
            const editButton = $(".edit-button[data-comment-id='" + commentId + "']");
            const editForm = $(".edit-form[data-comment-id='" + commentId + "']");


            editButton.show();
            editForm.hide();
        });
    });

    $(document).ready(function () {
        $(".edit-button").on("click", function () {
            const target = event.target;
            const commentId = $(this).data("comment-id");
            const editForm = $(this).closest(".comment-section").find(".edit-form");
            const saveButton = document.querySelector('.save-button');

            const commentContainer = document.querySelector('.comment');
            const commentElement = target.closest('.comment');
            const commentTextElement = commentElement.querySelector('.text');

            const oldText = commentElement.querySelector(".text").textContent;
            const editContent = commentContainer.querySelector(".comment-content");
            if (target.classList.contains('edit-button') || target.classList.contains('delete-button')) {

                $(this).hide();

                const commentElement = target.closest('.comment');
                const commentTextElement = commentElement.querySelector('.text');

                editForm.find("textarea").val(commentTextElement.textContent).focus();
                editForm.show();
                function updateSaveButtonState() {
                    const hasChanges = commentTextElement.textContent !== editContent.value;

                    if (hasChanges) {
                        saveButton.disabled = false;
                        saveButton.classList.remove('disabled');
                    } else {
                        saveButton.disabled = true;
                        saveButton.classList.add('disabled');

                    }
                }

                updateSaveButtonState();

                editContent.addEventListener('input', updateSaveButtonState);
            }

        });
    });

    $(document).ready(function () {
        $(".save-button").on("click", function () {

            const commentId = $(this).closest(".edit-form").data("comment-id");
            const commentTextarea = document.querySelector('.comment-content');
            const commentElement = document.querySelector('.page');

            const commentContainer = document.querySelector('.comment');
            const target = event.target;
            const commentContent = commentTextarea.value;

            const editForm = $(this).closest(".comment-section").find(".edit-form");

            const ajaxUrl = "https://localhost:7085/api/content/" + commentId;
            $.ajax({
                url: ajaxUrl,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify(commentContent),
                success: function (response) {
                    if (response.success) {
                        const commentElement = target.closest('.comment');
                        const hasSpanClass = commentElement.querySelector("edited-label");

                        if (!hasSpanClass) {
                            const editedSpan = document.createElement('span');
                            editedSpan.classList.add('edited-label');
                            editedSpan.textContent = '(edited)';

                            commentElement.prepend(editedSpan);
                        }

                        const commentTextElement = commentElement.querySelector('.text');

                        const commentTextarea = document.querySelector('.comment-content');

                        const text = commentElement.querySelector(".text");
                        commentTextElement.textContent = commentTextarea.value;

                        editForm.hide();
                        var editButton = $(".edit-button[data-comment-id='" + commentId + "']");
                        editButton.show();
                    } else {
                        console.log(response.errorMessage);
                    }
                },
                error: function () {
                    console.log("Failed");
                }
            });
        });
    });

function jokeConfirm(e) {
    e.preventDefault();
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: 'Cancel',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Deleted!',
                'The joke has been deleted.',
                'success'
            ).then((resultDeleted) => {
                e.target.parentElement.parentElement.submit();
            })
        }
    })
}

function commentConfirm(e) {
    e.preventDefault();
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: 'Cancel',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Deleted!',
                'The comment has been deleted.',
                'success'
            ).then((resultDeleted) => {
                e.target.parentElement.parentElement.submit();
            })
        }
    })
}