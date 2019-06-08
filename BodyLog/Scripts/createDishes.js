const buttonsAdd = document.querySelectorAll("button[name='addDishesButton']");
const buttonsRemove = document.querySelectorAll("button[name='removeProductButton']");
const inputsVolume = document.querySelectorAll(".inputsVolume");



document.querySelectorAll('.inputsVolume ').forEach((element) => {
    element.value = "";
})


for (let item of buttonsAdd) {
    item.addEventListener("click", (e) => {

        const tr = document.querySelector(`tr[data-productAdded='${e.target.id}'`);
        tr.style.display = "table-row";

        const productFromList = document.querySelector(`tr[data-productFromList='${e.target.id}'`);
        productFromList.style.opacity = 0.5;
        productFromList.querySelector("button").style.display = "none";

        test();
    });
}

for (let item of buttonsRemove) {
    item.addEventListener("click", (e) => {

        const tr = document.querySelector(`tr[data-productAdded='${e.target.id}'`);
        for (let column of tr.children) {
            if (column.dataset.factor) {
                column.innerHTML = "0";
            }
        }
        tr.querySelector('.inputsVolume').value = "";
        tr.style.display = "none";

        const productFromList = document.querySelector(`tr[data-productFromList='${e.target.id}'`);
        productFromList.style.opacity = 1;
        productFromList.querySelector("button").style.display = "block";

        test();
    });
}



for (let item of inputsVolume) {

    item.addEventListener("input",
        (e) => {
            let volume = e.target.value;
            if (isNaN(volume)) {
                e.target.value = "";
                volume = 0;
            }
            const id = e.target.parentElement.dataset.productedited;
            const tr = document.querySelector(`tr[data-productAdded='${id}'`);

            for (let column of tr.children) {
                if (column.dataset.factor) {
                    column.innerHTML = Math.round(column.dataset.factor * volume / 100);
                }
            }

        });
}

