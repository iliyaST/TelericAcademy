import { data } from './data.js';
import { router } from './routing.js';

$(() => { // on document ready
    const GLYPH_UP = 'glyphicon-chevron-up',
        GLYPH_DOWN = 'glyphicon-chevron-down',
        root = $('#root'),
        navbar = root.find('nav.navbar'),
        mainNav = navbar.find('#main-nav'),
        contentContainer = $('#root #content'),
        loginForm = $('#login'),
        logoutForm = $('#logout'),
        usernameSpan = $('#span-username'),
        usernameInput = $('#login input'),
        alertTemplate = $($('#alert-template').text());

    router.init();

    (function checkForLoggedUser() {
        data.users.current()
            .then((user) => {
                if (user) {
                    usernameSpan.text(user);
                    loginForm.addClass('hidden');
                    logoutForm.removeClass('hidden');
                }
            });
    })();

    function showMsg(msg, type, cssClass, delay) {
        let container = alertTemplate.clone(true)
            .addClass(cssClass).text(`${type}: ${msg}`)
            .appendTo(root);

        setTimeout(() => {
            container.remove();
        }, delay || 2000);
    }

    function getThreadUI(title, id, creator, date) {
        let template = $($('#thread-template').text()).attr('data-id', id),
            threadTitle = template.find('.thread-title').text(title),
            threadCreator = template.find('.thread-creator').text(creator || 'anonymous'),
            threadDate = template.find('.thread-date').text(date || 'unknown');

        return template.clone(true);
    }

    function getMsgUI(msg, author, date) {
        let template = $($('#messages-template').text());
        template.find('.message-content').text(msg);
        template.find('.message-creator').text(author || 'anonymous');
        template.find('.message-date').text(date || 'unknown');
        return template.clone(true);
    }

    // start threads
    function loadThreadsContent(threads) {
        let container = $($('#threads-container-template').text()),
            threadsContainer = container.find('#threads');

        function getAddNewThreadUI() {
            let template = $($('#thread-new-template').html());
            return template.clone(true);
        }

        threads.forEach((th) => {
            let date = th.postDate;

            if (th.postDate) {
                date = th.postDate.split('T')[0];
            }

            let currentThreadUI = getThreadUI(th.title, th.id, th.username, date);
            threadsContainer.append(currentThreadUI);
        });
        threadsContainer.append(getAddNewThreadUI());

        contentContainer.find('#container-thraeds').remove();
        contentContainer.html('').prepend(container);
    }

    function loadMessagesContent(data) {
        let container = $($('#messages-container-template').text()),
            messagesContainer = container.find('.panel-body');
        container.attr('data-thread-id', data.result.id);

        function getAddNewMsgUI() {
            let template = $($('#message-new-template').html());
            return template.clone(true);
        }

        if (data.result.messages && data.result.messages.length > 0) {
            data.result.messages.forEach((msg) => {
                messagesContainer.append(getMsgUI(msg.content, msg.username, msg.postDate.split('T')[0]));
            });
        } else {
            messagesContainer.append(getMsgUI('No messages!'));
        }

        messagesContainer.append(getAddNewMsgUI());

        container.find('.thread-title').text(data.result.title);
        contentContainer.append(container);
    }

    navbar.on('click', 'li', (ev) => {
        let $target = $(ev.target);
        $target.parents('nav').find('li').removeClass('active');
        $target.parents('li').addClass('active');
    });

    contentContainer.on('click', '#btn-add-thread', (ev) => {
        let title = $(ev.target).parents('form').find('input#input-add-thread').val() || null;
        data.threads.add(title)
            .then(thread => {
                thread = thread.result;
                let threadUI = getThreadUI(
                    thread.title,
                    thread.id,
                    thread.username,
                    thread.postDate.split('T')[0]);

                threadUI.insertBefore('.navbar-form.navbar-left');
            })
            .then(showMsg('Successfuly added the new thread', 'Success', 'alert-success'))
            .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
    });

    contentContainer.on('click', 'a.thread-title', (ev) => {
        let $target = $(ev.target),
            threadId = $target.parents('.thread').attr('data-id');

        data.threads.getById(threadId)
            .then(loadMessagesContent)
            // .catch((err) => showMsg(err, 'Error', 'alert-danger'));
    });

    contentContainer.on('click', '.btn-add-message', (ev) => {
        let $target = $(ev.target),
            $container = $target.parents('.container-messages'),
            thId = $container.attr('data-thread-id'),
            msg = $container.find('.input-add-message').val();

        data.threads.addMessage(thId, msg)
            .then(msgs => {
                let msg = msgs.messages[msgs.messages.length - 1];
                let messageUI = getMsgUI(
                    msg.content,
                    msg.username,
                    msg.postDate.split('T')[0]);

                let $thread = $(`div[data-thread-id="${thId}"]`);
                let $form = $thread.find('form[role="search"]');
                messageUI.insertBefore($form);
            })
            .then(showMsg('Successfuly added the new mssagee', 'Success', 'alert-success'))
            .then($container.find('.input-add-message').val(''))
            .catch(console.log);
        // .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
    });

    contentContainer.on('click', '.btn-close-msg', (ev) => {
        let msgContainer = $(ev.target).parents('.container-messages').remove();
    });

    contentContainer.on('click', '.btn-collapse-msg', (ev) => {
        let $target = $(ev.target);
        if ($target.hasClass(GLYPH_UP)) {
            $target.removeClass(GLYPH_UP).addClass(GLYPH_DOWN);
        } else {
            $target.removeClass(GLYPH_DOWN).addClass(GLYPH_UP);
        }

        $target.parents('.container-messages').find('.messages').toggle();
    });
    // end threads

    // start gallery
    // end gallery

    // start login/logout
    navbar.on('click', '#btn-login', (ev) => {
        let username = usernameInput.val() || 'anonymous';
        data.users.login(username)
            .then((user) => {
                usernameInput.val('')
                usernameSpan.text(user);
                loginForm.addClass('hidden');
                logoutForm.removeClass('hidden');
                $('.badge').text('43');
            });
    });
    navbar.on('click', '#btn-logout', (ev) => {
        data.users.logout()
            .then(() => {
                usernameSpan.text('');
                loginForm.removeClass('hidden');
                logoutForm.addClass('hidden');
                $('.badge').text('42');
            });
    });
    // end login/logout
});