$.fn.tabs = function() {
    let $element = $(this);
    let $previous;
    $element.addClass('tabs-container');
    let $second = $($('.tab-item')[1]);
    let $secondInner = $($('.tab-item-title')[1]);
    let secondTitle = $($second.children()[0]).text();

    $element.on('click', '.tab-item', function() {
        let $target = $(this);

        if ($($target.children()[0]).text() == secondTitle) {
            $secondInner.css('border-left', 'none');
        } else {
            $secondInner.css('border-left', '1px solid black');

        }

        if ($target !== $previous) {
            let $content = $($target.find('.tab-item-content')[0]);

            $content.css('z-index', '1000');

            if ($previous !== undefined) {
                $previous.removeClass('current');
                let $contentPrevious = $($previous.find('.tab-item-content')[0]);
                $contentPrevious.css('z-index', '-1');
            }
        }

        $target.addClass('current');

        $previous = $target;
    });
};