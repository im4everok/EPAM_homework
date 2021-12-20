const {listOfPosts} = require("./posts");
const getSum = (str1, str2) => {
  if(typeof str1 === 'string' && typeof str2 === 'string'){
    if(str1 === ''){
      str1 = 0;
    }
    if(str2 === ''){
      str2 = 0;
    }
    if(!isNaN(str1) && !isNaN(str2)){
      let res;
      res = (+str1) + (+str2);
      return res.toString(10);
    }
      return false;
  }
  else{
    return false;
  }
};

const getQuantityPostsByAuthor = (listOfPosts, authorName) => {
  let post = 0;
  let com = 0;
  for (let i = 0; i < listOfPosts.length; i++) {
    if (listOfPosts[i].author === authorName) {
      post++;
    }
    if (typeof listOfPosts[i].comments !== 'undefined'){
      for (let j = 0; j < listOfPosts[i].comments.length; j++) {
        if (listOfPosts[i].comments[j].author === authorName) {
          com++;
        }
      }
    }
  }
  return `Post:${post},comments:${com}`;
};

const tickets=(people)=> {
  let a25 = 0, a50 = 0, a100 = 0;
  for (let i = 0; i < people.length; i++) {
    if(Number(people[i]) === 25){
      a25++;
    }
    if(Number(people[i]) === 50){
        if(a25 >= 1){
          a50++;
          a25--;
        }
        else {
          return 'NO';
        }
    }
    if(Number(people[i]) === 100){
      a100++;
      if(a50 >= 1 && a25 >= 1){
        a50--;
        a25--;
      }
      else{
        if(a25 >= 3){
          a25 -= 3;
        }
        else {
          return 'NO';
        }
      }
    }
  }
  return 'YES';
};

module.exports = {getSum, getQuantityPostsByAuthor, tickets};
