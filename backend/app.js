const express = require("express");
const bodyParser = require("body-parser");
const path = require('path');
const request = require('request');
const multer = require("multer");
const storage = multer.diskStorage({
    destination: (req, file, callback) => {
        callback(null, 'images');
    },
    filename: (req, file, callback) =>{
        console.log(file);
        callback(null, Date.now()+path.extname(file.originalname));
    }
    
})
const upload =multer({storage:storage});

let mysql = require("mysql");

let connection = mysql.createConnection({
    host: 'vrestate.clbfq7mnbhip.eu-west-3.rds.amazonaws.com',
    port: '3306',
    user: 'admin',
    password: 'VRestate123**',
    database: 'vrestate'
});
const app = express();
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.use(function(req, res, next) {
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
    res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
    res.setHeader('Access-Control-Allow-Credentials', true);
    next();
});

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

app.get('/loaderio-0ea84b7e34801498d9390d93deb66294', (req,res) => {
    res.send('loaderio-0ea84b7e34801498d9390d93deb66294');
})

app.get('/apitest', (req,res) => {
    res.json({
        "keys": ["id"] ,
        "values": [
          ["1"],
          ["2"],
          ["3"],
          ["4"],
          ["5"],
          ["6"],
          ["7"],
          ["8"],
          ["9"],
          ["41"]
        ]
      });
});


//test için html donen endpoint. frontendi tamamlandığında silinecek
app.get('/imageupload', function (req, res) {
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write('<form action="/upload" enctype="multipart/form-data" method="post">');
    res.write(' <input type="file" name="image" accept="image/*">');
    res.write('<input type="submit" value="Upload">');
    res.write('</form>');
    return res.end();
})

app.post('/upload', upload.single("image"), (req,res) =>{
    if (!req.file) {
        console.log("No file upload");
    } else {
        console.log(req.file.filename)
        var imgsrc = req.file.filename
        var insertData = "INSERT INTO photos(file_src) VALUES (?)"
        connection.query(insertData, [imgsrc], (err, result) => {
            if (err) throw err
            console.log("file uploaded")
            connection.query('select file_id from photos order by 1 desc', (error, results, fields) => {
                if(err) throw err
                res.send({message: "File Uploaded",
                    id: results[0].file_id});
            })
        })
    }
}); 

app.get('/getImage', (req,res) => {
    if(req.query.id == null || req.query.id == ''){
        res.status(400).send({message:'FileID can not be null'})
        return;
    }
    let query = 'select * from photos where file_id =' +req.query.id;
    connection.query(query, (error, results) => {
        if(error){
            res.statusMessage ='Database Query Error';
            res.status(500).send({message:error});
            return;
        }
        if(results.length == 0){
            res.send('Image Not Found');
            return;
        }
        res.sendFile('images/'+results[0].file_src, {root:'.'});
    })
})


app.get('/login/check', (req,res) => {
    let query = 'SELECT * FROM vrestate.user WHERE mail = \''+req.query.mail+'\'';
    
    connection.query(query, (error, results, fields) => {
        if(error){
            res.statusMessage = 'Database Query Error: '+error;
            res.status(500).end();
            return console.error(error);
        }
        if(results.length == 0){
            res.statusMessage = 'User Not Found';
            res.status(400).end();
        }
        else{
            res.send(results[0]);
        }
        
    });
    
    
});

app.get('/login/getById', (req,res) => {
    let query = 'SELECT * FROM vrestate.user WHERE id = \''+req.query.id+'\'';
    
    connection.query(query, (error, results, fields) => {
        if(error){
            res.statusMessage = 'Database Query Error: '+error;
            res.status(500).end();
            return console.error(error);
        }
        if(results.length == 0){
            res.statusMessage = 'User Not Found';
            res.status(400).end();
        }
        else{
            res.send(results[0]);
        }
        
    });
    
    
});

app.post('/login', (req,res) => {
    let query = 'SELECT * FROM vrestate.user WHERE mail = \''+req.body.mail+'\'';
    
    connection.query(query, (error, results, fields) => {
        if(error){
            res.statusMessage = 'Database Query Error: '+error;
            res.status(500).end();
            return console.error(error);
        }
        if(results.length == 0){
            let query2 = 'INSERT INTO user (id,name,surname,mail) values (\''+req.body.id+'\',\''+req.body.name+'\',\''+req.body.surname+'\',\''+req.body.mail+'\')';
            connection.query(query2, (error, results, fields) => {
                if(error){
                    res.statusMessage = 'Database Query Error: '+error;
                    res.status(500).end();
                    return console.error(error);
                }
                else{

                    res.status(200);
                    res.send('User Successfully Created!');
                }
        
            });
        }
        else{
            res.send(results[0]);
        }
        
    });

    
});

//girilmeyen değerleri apiye null gönderelim.
app.post('/estate/create', (req,res) => {
    let query = "INSERT INTO estate (title, head_photo_id, estate_type, category, price, create_date, last_update, location_ilce, location_il, coordX, coordY, room_type, m2, vr_id, owner_id) VALUES ?;"
    let values = [];
    values[values.length] = req.body.title;
    values[values.length] = req.body.head_photo_id;
    values[values.length] = req.body.estate_type;
    values[values.length] = req.body.category;
    values[values.length] = req.body.price;
    let date = new Date().toISOString()
    values[values.length] = date;
    values[values.length] = date;
    values[values.length] = req.body.ilce;
    values[values.length] = req.body.il;
    values[values.length] = req.body.coordX;
    values[values.length] = req.body.coordY;
    values[values.length] = req.body.room_type;
    values[values.length] = req.body.m2;
    values[values.length] = req.body.vr_id;
    values[values.length] = req.body.owner_id;
    
    let createdId;
    connection.query(query, values, (error, results, fields) => {
        if(error){
            res.statusMessage ='Database Query Error';
            res.status(500).send({message:error});
            return;
        }
        query = 'select * from estate order by 1 desc'
        connection.query(query, (error, results, fields) => {
            if(error){
                res.statusMessage ='Database Query Error';
                res.status(500).send({message:error});
                return;
            }
            createdId = results[0].id;
        })
        //estate detail oluşturma.
        query = "INSERT INTO estate_detail (title, head_photo_id, estate_type, category, price, create_date, last_update, location_ilce, location_il, coordX, coordY, room_type, m2, vr_id, owner_id) VALUES ?;"
    })    
});

app.post('/estate/update');

app.post('/estate/delete');

app.get('/estate/getEstates');

//json mu gidiyor control.
app.get('/checkLocation', (req,res) => {
    let ip = req.socket.remoteAddress.substring(req.socket.remoteAddress.indexOf(':',2)+1);
    request('http://ip-api.com/json/'+ip, (error, response, body) => {
        if(error){
            res.status(400).send({message:error});
            return;
        }
        res.send(body)
        //res.send({country:body.country,region:body.regionName});
    })

})



app.listen(5002, () => {
    connection.connect(function(err) {
        if (err) {
          return console.error('error: ' + err.message);
        }
      
        console.log('Connected to the MySQL server.');
      });
    console.log('server started on port 5002');
});