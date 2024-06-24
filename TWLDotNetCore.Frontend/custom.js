function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function successMessage(message) {
    // alert(message);
    Swal.fire({
        title: "Show Message!",
        text: "You clicked the button!",
        icon: message
    });
}

function errorMessage(message) {
    // alert(message);
    Swal.fire({
        title: "Show Message!",
        text: "You clicked the button!",
        icon: message
    });
}