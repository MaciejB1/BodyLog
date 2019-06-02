const buttonsAdd = document.querySelectorAll("button[name='addDishesButton']");
const buttonsRemove = document.querySelectorAll("button[name='removeProductButton']");
const inputsVolume = document.querySelectorAll(".inputsVolume");

for (let item of buttonsAdd) {
    item.addEventListener("click", (e) => {
       
        const tr = document.querySelector(`tr[data-productAdded='${e.target.id}'`);
        tr.style.display = "table-row";

        const productFromList = document.querySelector(`tr[data-productFromList='${e.target.id}'`);
        productFromList.style.opacity = 0.5;
        productFromList.querySelector("button").style.display = "none";
    });
}

for (let item of buttonsRemove) {
    item.addEventListener("click", (e) => {

        const tr = document.querySelector(`tr[data-productAdded='${e.target.id}'`);
        tr.style.display = "none";

        const productFromList = document.querySelector(`tr[data-productFromList='${e.target.id}'`);
        productFromList.style.opacity = 1;
        productFromList.querySelector("button").style.display = "block";
    });
}



for (let item of inputsVolume) {

    item.addEventListener("input", (e) => {
        const volume = e.target.value;
        const id = e.target.name.match(/\d/g).join("");

        const tr = document.querySelector(`tr[data-productAdded='${id}'`);
        console.log(e.target)
        console.log(tr);
       
    });
}