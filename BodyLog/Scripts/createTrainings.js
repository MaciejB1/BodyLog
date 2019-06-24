const buttonsAdd = document.querySelectorAll("button[name='addActivityButton']");
const buttonsRemove = document.querySelectorAll("button[name='removeActivityButton']");











for (let item of buttonsAdd) {
    item.addEventListener("click", (e) => {

        const tr = document.querySelector(`tr[data-activityAdded='${e.target.id}'`);
        tr.style.display = "table-row";

        const activityFromList = document.querySelector(`tr[data-activityFromList='${e.target.id}'`);
        activityFromList.style.opacity = 0.5;
        activityFromList.querySelector("button").style.display = "none";

        test();
    });
}

for (let item of buttonsRemove) {
    item.addEventListener("click", (e) => {

        const tr = document.querySelector(`tr[data-activityAdded='${e.target.id}'`);
        for (let column of tr.children) {
            if (column.dataset.factor) {
                column.innerHTML = "0";
            }
        }
        
        tr.style.display = "none";

        const activityFromList = document.querySelector(`tr[data-activityFromList='${e.target.id}'`);
        activityFromList.style.opacity = 1;
        activityFromList.querySelector("button").style.display = "block";

        test();
    });
}






