window.onload = function () {

    let hova = document.getElementById("ide");
    let sor = document.createElement("div");
    sor.classList.add("sor");
    hova.appendChild(sor);

    for (var i = 0; i < 10; i++) {
        let szam = document.createElement("div");
        sor.appendChild(szam);
        szam.classList.add("doboz");
        szam.innerText = i + 1;
        szam.style.background = `rgb(${255 - (20 * i)},0,0)`
    }


    var faktoriális = function (n) {
        let er = 1;
        for (let i = 2; i <= n; i++) {
            er = er * i;
        }
        return er;
    }


    for (var i = 0; i < 10; i++) {

        let where = document.getElementById("pascal");
        let row = document.createElement("div");
        row.classList.add("row");
        where.appendChild(row);

        for (var j = 0; j <= i; j++) {

            let number = document.createElement("div");
            row.appendChild(number);
            number.classList.add("box");
            number.innerText = faktoriális(i) / (faktoriális(j) * (faktoriális(i - j)));
        }
    }

}