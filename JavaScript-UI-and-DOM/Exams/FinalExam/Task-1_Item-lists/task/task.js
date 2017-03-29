function solve() {

    return function(selector) {

        var defaultLeft = arguments[1];
        var defaultRight = arguments[2];

        if (defaultLeft == undefined) {
            defaultLeft = [];
        }

        if (defaultRight == undefined) {
            defaultRight = [];
        }

        var element = document.querySelector(selector);
        var columContainer = document.createElement('div');
        var colum1 = document.createElement('div');
        var colum2 = document.createElement('div');
        var addInput = document.createElement('input');
        var addButton = document.createElement('button');

        addButton.innerHTML = 'Add';

        columContainer.className = 'column-container';
        colum1.className = 'column';
        colum2.className = 'column';

        // colums content
        var select1 = document.createElement('div');
        select1.className = 'select';
        var select2 = document.createElement('div');
        select2.className = 'select';

        // ols
        var oList1 = document.createElement('ol');
        var oList2 = document.createElement('ol');

        //fill olList1
        for (var i = 0; i < defaultLeft.length; i += 1) {
            var list1 = document.createElement('li');
            var deleteButton = document.createElement('img');
            deleteButton.className = 'delete';
            deleteButton.src = 'imgs/Remove-icon.png';

            list1.className = 'entry';


            list1.innerHTML = defaultLeft[i];
            list1.appendChild(deleteButton);


            oList1.appendChild(list1);
        }

        //fill olList2
        for (var i = 0; i < defaultRight.length; i += 1) {
            var list2 = document.createElement('li');
            var deleteButton = document.createElement('img');
            deleteButton.className = 'delete';
            deleteButton.src = 'imgs/Remove-icon.png';

            list2.className = 'entry';


            list2.innerHTML = defaultRight[i];
            list2.appendChild(deleteButton);

            oList2.appendChild(list2);
        }


        // selectors content
        var radio1 = document.createElement('input');
        var radio2 = document.createElement('input');

        //default left should be selected
        radio1.checked = true;

        // types
        radio1.type = 'radio';
        radio1.name = "radAnswer";
        radio2.type = 'radio';
        radio2.name = "radAnswer";

        // append radios
        select1.appendChild(radio1);
        select2.appendChild(radio2);

        //append selecets		
        colum1.appendChild(select1);
        colum2.appendChild(select2);
        colum1.appendChild(oList1);
        colum2.appendChild(oList2);

        //append colums
        columContainer.appendChild(colum1);
        columContainer.appendChild(colum2);

        element.appendChild(columContainer);
        element.appendChild(addInput);
        element.appendChild(addButton);

        element.addEventListener('click', function(event) {
            var target = event.target;

            if (target.className == 'delete') {
                var parent = target.parentElement;
                var parentOl = parent.parentElement;

                parent.removeChild(target);
                addInput.value = parent.innerHTML;
                parentOl.removeChild(parent);
            }
        });


        // Add
        addButton.addEventListener('click', function() {
            var inputText = addInput.value.trim();

            if (inputText != '') {
                if (radio1.checked == true) {
                    // Append to list 1
                    var list1 = document.createElement('li');
                    var deleteButton = document.createElement('img');

                    deleteButton.className = 'delete';
                    deleteButton.src = 'imgs/Remove-icon.png';

                    list1.className = 'entry';


                    list1.innerHTML = inputText;
                    list1.appendChild(deleteButton);


                    oList1.appendChild(list1);
                } else {
                    // append to list 2
                    var list2 = document.createElement('li');
                    var deleteButton = document.createElement('img');

                    deleteButton.className = 'delete';
                    deleteButton.src = 'imgs/Remove-icon.png';

                    list2.className = 'entry';

                    list2.innerHTML = inputText;
                    list2.appendChild(deleteButton);


                    oList2.appendChild(list2);
                }

                addInput.value = '';
            }
        });
    };
}


if (typeof module !== 'undefined') {
    module.exports = solve;
}