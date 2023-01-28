const express = require("express");
let mysql = require("mysql");
let connection = mysql.createConnection({
    host: 'vrestate.clbfq7mnbhip.eu-west-3.rds.amazonaws.com',
    port: '3306',
    user: 'admin',
    password: 'VRestate123**',
    database: 'vrestate'
});
const app = express();

app.get('/testapi', (req,res) => {
    let query = 'SELECT name FROM vrestate.test WHERE id = '+req.query.id;
    
    connection.query(query, (error, results, fields) => {
        if(error){
            return console.error(error);
        }
        if(results.length == 0){
            res.send('Kullanici Bulunamadi!');
        }
        else{
            res.send((req.query.id)+ ' nolu id ye sahip kullanici ' + results[0].name);
            console.log(results[0].name)
        }
        
    });
    
    
});

app.listen(5002, () => {
    connection.connect(function(err) {
        if (err) {
          return console.error('error: ' + err.message);
        }
      
        console.log('Connected to the MySQL server.');
      });
    console.log('server started on port 5002');
});