const buttonsAdd = document.querySelectorAll("button[name='addDishesButton']");
const buttonsRemove = document.querySelectorAll("button[name='removeProductButton']");
const inputsVolume = document.querySelectorAll(".inputsVolume");

document.querySelectorAll('.inputsVolume ').forEach((element) => {

    if (element.value === "0") {
        element.value = "";
    } else {
        let id = element.parentNode.parentNode.dataset.productadded;
        add(id);
    }

  
})

function valid(){
    const inputName = document.querySelector("input[name='Dishes.Name']");
    const validMessage = document.getElementById("validMessage");
    validMessage.innerHTML = "";
    let valid = true;
        inputName.style.border = "1px solid #cccccc";
    
    if (inputName.value.length < 1) {
        inputName.style.border = "1px solid red";
        validMessage.innerHTML = `Uzupełnij nazwę dania! \n`;
        valid = false;
    }


    let count = 0;
    let flag = false;
    for (let item of inputsVolume) {
        if (item.parentElement.parentElement.style.display == "table-row") {
            count++;
            item.style.border = "1px solid #cccccc";
            if (item.value.length < 1) {
                if(!flag)
                    validMessage.innerHTML +=  `Wprowadź ilość w gramach dla każdego wybranego produktu! \n`
                item.style.border = "1px solid red";
                valid = false;
                flag = true;
            }
            
        }
    }

    if (count == 0) {
        validMessage.innerHTML +=  "Nie wybrałeś żadnego produktu!";
        valid = false;
    }

    return valid;
}




function add(e) {
    const tr = document.querySelector(`tr[data-productAdded='${e}'`);
    tr.style.display = "table-row";

    const productFromList = document.querySelector(`tr[data-productFromList='${e}'`);
    productFromList.style.opacity = 0.5;
    productFromList.querySelector("button").style.display = "none";
}

function remove(e) {
    const tr = document.querySelector(`tr[data-productAdded='${e}'`);
    for (let column of tr.children) {
        if (column.dataset.factor) {
            column.innerHTML = "0";
        }
    }
    tr.querySelector('.inputsVolume').value = "";
    tr.style.display = "none";

    const productFromList = document.querySelector(`tr[data-productFromList='${e}'`);
    productFromList.style.opacity = 1;
    productFromList.querySelector("button").style.display = "block";
}

function input(volume, id) {
    const tr = document.querySelector(`tr[data-productAdded='${id}'`);

    for (let column of tr.children) {
        if (column.dataset.factor) {
            column.innerHTML = Math.round(column.dataset.factor * volume / 100);
        }
    }
}


for (let item of buttonsAdd) {
    item.addEventListener("click", (e) => {
        add(e.target.id);
    });
}

for (let item of buttonsRemove) {
    item.addEventListener("click", (e) => {
        remove(e.target.id);
    });
}



for (let item of inputsVolume) {
    input(item.value, item.parentElement.dataset.productedited);

    setInputFilter(item, function (value) {
        return /^\d*$/.test(value) && (value === "" || parseInt(value) > 0);
    })

    item.addEventListener("input", (e) => {
  
        input(e.target.value, e.target.parentElement.dataset.productedited);
    });

}
function setInputFilter(textbox, inputFilter) {
    ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            }
        });
    });
}