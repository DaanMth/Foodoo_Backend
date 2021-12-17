import http from 'k6/http';
import {sleep, check} from 'k6';

export let options ={
    insecureSkipTLSVerify : true,
    noConnectionReuse: false,
    stages:[
        {duration: '5m', target: 150},
        {duration: '10m', target: 150},
        {duration: '5m', target: 0},
        
        
    ],
    tresholds:{
        http_req_duration:['p(99)<200'],
        http_req_failed:['rate<0.01'] 
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