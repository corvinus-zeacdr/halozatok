window.onload = function(){
    letöltés();
}

var kérdések;
var kérdésSorszám = 0;

function letöltés() {
    fetch('/questions.json')
        .then(response => response.json())
        .then(data => letöltésBefejeződött(data)
        );

    function letöltésBefejeződött(d) {
        console.log("Sikeres letöltés")
        console.log(d)
        kérdések = d;
        kérdésMegjelenítés(kérdésSorszám)
    }
}


function kérdésMegjelenítés(kérdés) {
    document.getElementById("kérdés_szöveg").innerHTML = kérdések[kérdés].questionText;
    document.getElementById("válasz1").innerHTML = kérdések[kérdés].answer1;
    document.getElementById("válasz2").innerHTML = kérdések[kérdés].answer2;
    document.getElementById("válasz3").innerHTML = kérdések[kérdés].answer3;

    if (kérdések[kérdés].image != "") {
        document.getElementById("kép1").src = "https://szoft1.comeback.hu/hajo/" + kérdések[kérdés].image;

    }
    else {
        document.getElementById("kép1").src = "";
    }
}


function válaszok(n) {
    if (n == kérdések[kérdésSorszám].correctAnswer) {
        document.getElementById("válasz" + n).classList.add("jo");
    }
    else {
        document.getElementById("válasz" + n).classList.add("rossz");
    }
}

function Clear() {
    document.getElementById("válasz1").classList.remove("jo");
    document.getElementById("válasz1").classList.remove("rossz");
    document.getElementById("válasz2").classList.remove("jo");
    document.getElementById("válasz2").classList.remove("rossz");
    document.getElementById("válasz3").classList.remove("jo");
    document.getElementById("válasz3").classList.remove("rossz");
}


function elsőVálasz(){
    válaszok(1);
}

function másodikVálasz(){
    válaszok(2);
}

function harmadikVálasz(){
    válaszok(3);
}

function Vissza() {

    if (kérdésSorszám == 0) {
        kérdésSorszám = kérdések.length - 1;
        letöltés()
        Clear()
    }
    else {
        kérdésSorszám--;
        letöltés();
        Clear()
    }
}

function Előre() {

    if (kérdésSorszám == kérdések.length - 1) {
        kérdésSorszám = 0;
        letöltés()
        Clear()
    }
    else {
        kérdésSorszám++;
        letöltés();
        Clear()
    }
}


