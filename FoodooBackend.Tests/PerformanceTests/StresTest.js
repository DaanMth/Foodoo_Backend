import http from 'k6/http';
import {sleep, check} from 'k6';

export let options ={
    insecureSkipTLSVerify : true,
    noConnectionReuse: false,
    stages:[
        {duration: '5s', target: 100},
        {duration: '10s', target: 100},
        {duration: '5s', target: 200},
        {duration: '10s', target: 200},
        {duration: '5s', target: 300},
        {duration: '10s', target: 300},
        {duration: '5s', target: 400},
        {duration: '10s', target: 400},
        {duration: '5s', target: 0},
    ],
    tresholds:{
    }
}

const base_url = 'https://localhost:5001'
export default () => {
    const responses = http.batch([
        ['GET', `${base_url}/GetPageRecipes`]
    ])
    check(responses[0], {
        'status is' : res => res.status  === 200
    })
    sleep(1);
}