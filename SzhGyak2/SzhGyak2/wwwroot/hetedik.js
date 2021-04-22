window.onload = function(){
    /*letöltés();*/
}

var aktKérdés;
var kérdésSorszám = 0;

/*function letöltés() {*/
    //fetch('/questions.json')
    //    .then(response => response.json())
    //    .then(data => letöltésBefejeződött(data)
    //);


    //fetch('/questions/4')
    //    .then(response => response.json())
    //    .then(data => console.log(data)
    //);

    fetch('/questions/1')
        .then(response => response.json())
        .then(data => kérdésMegjelenítés(data)
    );


    //function letöltésBefejeződött(d) {
    //    console.log("Sikeres letöltés")
    //    console.log(d)
    //    kérdések = d;
    //    kérdésMegjelenítés(kérdésSorszám)
    //}
/*}*/


//function kérdésMegjelenítés(kérdés) {
//    document.getElementById("kérdés_szöveg").innerHTML = kérdések[kérdés].questionText;
//    document.getElementById("válasz1").innerHTML = kérdések[kérdés].answer1;
//    document.getElementById("válasz2").innerHTML = kérdések[kérdés].answer2;
//    document.getElementById("válasz3").innerHTML = kérdések[kérdés].answer3;

//    if (kérdések[kérdés].image != "") {
//        document.getElementById("kép1").src = "https://szoft1.comeback.hu/hajo/" + kérdések[kérdés].image;

//    }
//    else {
//        document.getElementById("kép1").src = "";
//    }
//}


function kérdésBetöltés(id) {
    fetch(`/questions/${id}`)
        .then(response => {
            if (!response.ok) {
                console.error(`Hibás válasz: ${response.status}`)
            }
            else {
                return response.json()
            }
        })
        .then(data => kérdésMegjelenítés(data));
}    


//function kérdésBetöltés(id) {
//    fetch(`/questions/${id}`)
//        .then(válaszfeldolgozás)
//        .then(kérdésMegjelenítés);
//}    


function válaszfeldolgozás(válasz) {
    if (!válasz.ok) {
        console.error(`Hibás válasz: ${response.status}`)
    }
    else {
        return válasz.json()
    }
}



function kérdésMegjelenítés(kérdés) {
    aktKérdés = kérdés;
    console.log(kérdés);
    document.getElementById("kérdés_szöveg").innerText = kérdés.questionText
    document.getElementById("válasz1").innerText = kérdés.answer1
    document.getElementById("válasz2").innerText = kérdés.answer2
    document.getElementById("válasz3").innerText = kérdés.answer3
    document.getElementById("kép1").src = "https://szoft1.comeback.hu/hajo/" + kérdés.image;

    if (kérdés.image != "") {
       document.getElementById("kép1").src = "https://szoft1.comeback.hu/hajo/" + kérdés.image;

    }
   else {
       document.getElementById("kép1").src = "";
    }


}


function válaszok(n) {
    if (n == aktKérdés.correctAnswer) {
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

    //if (kérdésSorszám == 0) {
    //    kérdésSorszám = kérdések.length - 1;
    //    letöltés()
    //    Clear()
    //}
    //else {
    //    kérdésSorszám--;
    //    letöltés();
    //    Clear()
    //}

    if (kérdésSorszám == 1) {
        kérdésSorszám = 859;
    }
    else {
        kérdésSorszám--;   
    }

    
    kérdésBetöltés(kérdésSorszám);
    Clear()
}

function Előre() {

    //if (kérdésSorszám == kérdések.length - 1) {
    //    kérdésSorszám = 0;
    //    letöltés()
    //    Clear()
    //}
    //else {
    //    kérdésSorszám++;
    //    letöltés();
    //    Clear()
    //}


    if (kérdésSorszám == 859) {
        kérdésSorszám = 1;
    }
    else {
        kérdésSorszám++;
    }

    kérdésBetöltés(kérdésSorszám);
    Clear()
}


