function openNav() {
    document.getElementById("mysidebar").style.width = "250px";
    document.getElementById("main-mobile").style.marginRight = "250px";
    document.getElementById("btn").style.display = "none";
}

function closeNav() {
    document.getElementById("mysidebar").style.width = "0";
    document.getElementById("main-mobile").style.marginRight = "0";

}


var dropdown = document.getElementsByClassName("dropdown-btn");
var i;
for (i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function () {
        var dropdownContent = this.nextElementSibling;
        if (dropdownContent.style.display === "block") {
            dropdownContent.style.display = "none";
        }
        else {
            dropdownContent.style.display = "block";
        }
    });
}
////////////////////////////////////مطالب//////////////////

function openPage(pageName) {
    var i, tabcontent;

    tabcontent = document.getElementsByClassName("tabcontent");

    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    document.getElementById(pageName).style.display = "block";
}

document.getElementById("defaultopen").click();


//////////////////////search////////////////////////

document.getElementById('myInput').addEventListener('keypress', function (event) {
    if (event.keyCode == 13) {
        var myId = document.getElementById('myInput').value;

        window.open("/Home/Search/" + myId);
    }
})