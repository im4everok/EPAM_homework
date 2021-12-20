const validateTitle = (value) => {
  if(typeof value != 'string'){
    return 'Incorrect input data';
  }
  if(value.length <= 2 || value.length >= 20 || !isNaN(value[0])){
    return 'INVALID';
  }
  if(typeof(value) == 'string' && value.charAt(0) === value.charAt(0).toUpperCase()){
    return 'VALID';
  }
}

const sum = (value1, value2) => {
  let numberVal;
  let stringVal;
  if(typeof value1 === 'string' && typeof value2 === 'number'){
    stringVal = value1;
    numberVal = value2;
  }
  if(typeof value2 === 'string' && typeof value1 === 'number'){
    stringVal = value2;
    numberVal = value1;
  }
  if((numberVal % 3) === 0 && (numberVal % 5) === 0 && (numberVal % 15) === 0){
    numberVal = numberVal * (-1);
  }
  return numberVal + (+stringVal);
};

module.exports = {
  validateTitle,
  sum,
};
