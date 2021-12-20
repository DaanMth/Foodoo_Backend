﻿import http from 'k6/http';
import {sleep, check} from 'k6';

export let options ={
    insecureSkipTLSVerify : true,
    noConnectionReuse: false,
    stages:[
        {duration: '20s', target: 10},
        {duration: '5s', target: 200},
        {duration: '20s', target: 10}
        
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