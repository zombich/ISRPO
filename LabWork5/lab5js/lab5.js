console.log("123");

let clickCount = 0;
document.querySelector('.button-class').addEventListener('click', () => {
    clickCount++;
    console.log('Button pressed', clickCount, 'times');
});
