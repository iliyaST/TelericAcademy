function solve() {

    return function(selector, rows, columns) {

        var $element = $(selector);
        var $previous;
        var $previousCol;
        var previousIndex;
        var $preiviousFullRowSelected;
        var isClicked = false;
        var $startingPointForDragiing;

        var alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];


        function unSelectAll($table) {
            var $rows = $table.children();
            for (var i = 0; i < $rows.length; i += 1) {
                let $cols = $($rows[i]).children();
                for (let j = 0; j < $cols.length; j += 1) {
                    $($cols[j]).removeClass('selected');
                }
            }
        }

        function selectALL($table) {
            var $rows = $table.children();
            for (var i = 0; i < $rows.length; i += 1) {
                let $cols = $($rows[i]).children();
                for (let j = 0; j < $cols.length; j += 1) {
                    $($cols[j]).addClass('selected');
                }
            }
        }


        var $table = $('<table>')
            .addClass('spreadsheet-table');

        for (var i = 0; i < rows + 1; i += 1) {
            var tr = $('<tr>');

            //Zero row fill
            if (i == 0) {
                var trH = $('<tr>');
                for (var j = 0; j < columns + 1; j += 1) {
                    if (j == 0) {
                        var th = $('<th>')
                            .addClass('spreadsheet-item')
                            .addClass('spreadsheet-header')

                        trH.append(th);
                    } else {
                        var th = $('<th>')
                            .addClass('spreadsheet-item')
                            .addClass('spreadsheet-header')
                            .html(alphabet[j - 1]);

                        trH.append(th);
                    }
                }
                $table.append(trH);
                continue;
            }

            //Others
            for (var j = 0; j < columns + 1; j += 1) {
                if (j == 0) {
                    var th = $('<th>')
                        .addClass('spreadsheet-item')
                        .addClass('spreadsheet-header')
                        .html(i)
                        .appendTo(tr);

                    continue;
                }

                var td = $('<td>')
                    .addClass('spreadsheet-item')
                    .addClass('spreadsheet-cell')
                    .attr('data-index', j);

                var span = $('<span>').appendTo(td);
                var input = $('<input>').appendTo(td);

                td.appendTo(tr);
            }

            $table.append(tr);
        }

        $element.append($table);


        $table.on('mousedown', '.spreadsheet-cell', function() {

            unSelectAll($table);

            var $target = $(this);
            $startingPointForDragiing = $target;
            isClicked = true;
            var $parent = $target.parent();
            var $currentRow = $($parent.children()[0]);

            //find Current colum
            var $currentColToSelect = $($($table.children()[0]).children()[$target.attr('data-index')]);
            $currentColToSelect.addClass('selected');

            $target.addClass('selected');
            $currentRow.addClass('selected');
        });


        $table.on('mousedown', '.spreadsheet-header', function() {

            var $target = $(this);

            ////unmark all
            unSelectAll($table);

            //select all Rows
            if (isNaN($target.text()) == false) {

                unSelectAll($table);

                if ($target.text() != '') {
                    var $currentRow = $target.parent();
                    var $allColums = $currentRow.children();

                    //Mark all
                    for (var col = 0; col < $allColums.length; col += 1) {
                        $($allColums[col]).addClass('selected');
                    }
                } else {
                    selectALL($table);
                }
            } else if (typeof($target.text()) == 'string') {

                unSelectAll($table);
                //find index
                var index;
                var text = $target.text();
                for (var i = 0; i < alphabet.length; i += 1) {
                    if (alphabet[i] == text) {
                        index = i + 1;
                        previousIndex = index;
                        break;
                    }
                }

                //mark all colums
                for (var row = 0; row < rows + 1; row += 1) {
                    var $getCurrentRow = $($table.children()[row]);
                    $($getCurrentRow.children()[index]).addClass('selected');
                }
            }
        });

        $(document).on("dblclick", '.spreadsheet-cell', function() {
            let $target = $(this);
            let $span = $($target.children()[0]);
            let $input = $($target.children()[1]);


            $target.addClass('editing');
            $input.focus();
        });

        // when enter button is pressed to save value in the cell
        $table.on('keyup', 'input', function(event) {
            if (event.keyCode == 13) {
                let $target = $(this);
                let $span = $target.prev();


                $span.text($target.val());
                $target.parent().removeClass('editing');
            }
        });

        $table.on('blur', 'input', function() {
            $(this).parent().removeClass('editing');
            $(this).prev().text($(this).val());
        });

        $(document).on('mousemove', function(event) {
            if (isClicked) {
                let $target = $(event.target);
                $target.addClass('selected');
                let $startingRow = $startingPointForDragiing.parent();
                let startingRow = Number($($startingRow.children()[0]).text());
                let startingIndex = $startingPointForDragiing.attr('data-index');
                let targetIndex = $target.attr('data-index');
                let $targetRow = $target.parent();
                let targetRow = Number($($targetRow.children()[0]).text());


                let getRows = $table.children();

                for (let row = startingRow; row < getRows.length; row += 1) {
                    let $currentRow = $(getRows[row]);
                    let tdsToFill = $currentRow.children();

                    for (let col = startingIndex; col < tdsToFill.length; col += 1) {

                        if (col == targetIndex) {
                            $(tdsToFill[col]).addClass('selected');
                            break;
                        }

                        $(tdsToFill[col]).addClass('selected');
                    }
                }
            }
        });

        $(document).on('mouseup', function() {
            isClicked = false;
        });

    };
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
    module.exports = solve;
}