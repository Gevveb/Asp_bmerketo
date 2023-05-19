function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)


function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }
}
toggleMenu('[data-option="toggle"]')


const checkLength = (element, minLength = 2) => {

    if (element.target.value.length < minLength) {
        document.getElementById(element.target.id).classList.add('redError')
        document.getElementById(`${element.target.id}ErrorMessage`).innerHTML = `The ${element.target.id} must contain at least ${minLength} characters`
    } else {
        document.getElementById(element.target.id).classList.remove('redError')
        document.getElementById(`${element.target.id}ErrorMessage`).innerText = ""
    }
}



const checkEmail = (element, message) => {
    if (message === undefined)
        message = `Your ${element.target.id} must be a valid e-mail`
    if (!element.target.value.match(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)) {
        document.getElementById(element.target.id).classList.add('redError')
        document.getElementById(`${element.target.id}ErrorMessage`).innerHTML = `Your ${element.target.id} must be a valid e-mail`
    } else {
        document.getElementById(element.target.id).classList.remove('redError')
        document.getElementById(`${element.target.id}ErrorMessage`).innerText = ""
    }
}
const checkPassword = (element, message) => {
    if (message === undefined)
        message = `Your ${element.target.id} must be a valid e-mail`
    if (!element.target.value.match(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/)) {
        document.getElementById(element.target.id).classList.add('redError')
        document.getElementById(`${element.target.id}ErrorMessage`).innerHTML = `Your ${element.target.id} must be a valid Password`
    } else {
        document.getElementById(element.target.id).classList.remove('redError')
        document.getElementById(`${element.target.id}ErrorMessage`).innerText = ""
    }
}


const validate = (e) => {
    switch (e.target.type) {
        case "text":
            checkLength(e, 2)
            break;
        case "email":
            checkEmail(e)
            break;
        case "password":
            checkPassword(e)
            break;
        case "textarea":
            checkLength(e, 5)
            break;

    }
}