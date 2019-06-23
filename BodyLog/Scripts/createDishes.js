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
    if (inputName.value.length < 1) {
        inputName.style.border = "1px solid red";
        validMessage.innerHTML = "Uzupełnij nazwę dania!";
        return false;
    }
    let count = 0;
    for (let item of inputsVolume) {
        if (item.parentElement.parentElement.style.display == "table-row") {
            count++;
            if (item.value.length < 1) {
                validMessage.innerHTML = "Wprowadź ilość w gramach dla każdego wybranego produktu!"
                item.style.border = "1px solid red";
                return false;
            }  
        }
    }

    if (count == 0) {
        validMessage.innerHTML = "Nie wybrałeś żadnego produktu!";
        return false;
    }

    return true;
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
  
    item.addEventListener("input", (e) => {
        console.log(e.target.parentElement.dataset.productedited);
        input(e.target.value, e.target.parentElement.dataset.productedited);
    });

}