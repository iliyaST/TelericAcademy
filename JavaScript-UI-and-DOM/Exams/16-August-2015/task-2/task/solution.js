function solve() {
    return function(fileContentsByName) {
        var $fileExporer = $('.file-explorer');
        var $addInput = $('input');
        var $itemsList = $('.items').first();
        var $addButton = $('.add-btn');

        $fileExporer.on('click', function(event) {
            var $target = $(event.target),
                $parent = $target.parent();

            if ($parent.hasClass('dir-item')) {
                $parent.toggleClass('collapsed');
            }

            if ($parent.hasClass('file-item')) {
                $('.file-content').text(fileContentsByName[$target.html()] || '');
            }

            if ($target.hasClass('add-btn')) {
                $target.removeClass('visible');
                $addInput.addClass('visible');
            }

            if ($target.hasClass('del-btn')) {
                $parent.remove();
            }

        });

        $addInput.on('keydown', function(event) {
            if (event.keyCode == 13) {
                var inputText = $(this).val();
                var index = inputText.indexOf('/');
                var folderName = inputText.substr(0, index);
                var fileName = inputText.substr(index + 1, inputText.length);


                if (index < 0) {
                    var $itemToAdd = $('<li/>')
                        .addClass('file-item')
                        .addClass('item');
                    $('<a/>')
                        .addClass('item-name')
                        .text(inputText)
                        .appendTo($itemToAdd);
                    $('<a/>')
                        .addClass('del-btn')
                        .appendTo($itemToAdd);

                    fileContentsByName[inputText] = '';
                    $itemToAdd.appendTo($itemsList);
                } else {
                    fileContentsByName[fileName] = '';
                    var targetFolder;
                    var findItems = $('.item-name');

                    for (var i = 0; i < findItems.length; i += 1) {
                        var $item = $(findItems[i]);
                        if ($item.text() == folderName) {
                            var $parrentOfItem = $($item.parents()[0]);
                            var $listWhereToAdditem = $parrentOfItem.find('.items');

                            var $itemToAdd = $('<li/>')
                                .addClass('file-item')
                                .addClass('item');
                            $('<a/>')
                                .addClass('item-name')
                                .text(fileName)
                                .appendTo($itemToAdd);
                            $('<a/>')
                                .addClass('del-btn')
                                .appendTo($itemToAdd);

                            $itemToAdd.appendTo($listWhereToAdditem);
                            break;
                        }
                    }
                }

                $addInput.removeClass('visible');
                $addButton.addClass('visible');
                $addInput.val('');
            }
        });

    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}