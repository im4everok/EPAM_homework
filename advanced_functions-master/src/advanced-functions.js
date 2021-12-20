//=============================================
// ------------------------------------ TASK №1
//=============================================
const cache = (func) => {
    let memo = {};
    let slice = Array.prototype.slice;

    return function() {
        let args = slice.call(arguments);

        if (args in memo)
            return memo[args];
        else
            return (memo[args] = func.apply(this, args));
    }
}

//=============================================
// ------------------------------------ TASK №2
//=============================================
const forwardBackwardSteps = {
    step : 0,
    forward (){
        this.step++;
        return this;
    },
    backward (){
        this.step--;
        return this;
    },
    revealStep (){
        console.log(this.step);
        return this;
    }
};

//=============================================
// ------------------------------------ TASK №3
//=============================================
const applyAll = (func, ...values) => {
    return func(...values);
}
const sum = (...args) => {
    return args.reduce((acc, val) => acc + val);
}

const mul = (...args) => {
    return args.reduce((acc, val) => acc * val);
}

//=============================================

module.exports = {cache, forwardBackwardSteps, applyAll, sum, mul}
