const buttons = document.querySelectorAll("button[name='addDishesButton']");
const buttonsRemove = document.querySelectorAll("button[name='removeProductButton']");

console.log(buttonsRemove)

for (let item of buttons) {
    item.addEventListener("click", (e) => {
       
        const tr = document.querySelector(`tr[data-productAdded='${e.target.id}'`);
        tr.style.display = "table-row";

        const productFromList = document.querySelector(`tr[data-productFromList='${e.target.id}'`);
        productFromList.style.display = "none";
    });
}

for (let item of buttonsRemove) {
    item.addEventListener("click", (e) => {

        console.log(e.target)

        const tr = document.querySelector(`tr[data-productAdded='${e.target.id}'`);
        tr.style.display = "none";

        const productFromList = document.querySelector(`tr[data-productFromList='${e.target.id}'`);
        productFromList.style.display = "table-row";
    });
}