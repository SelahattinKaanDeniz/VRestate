const express = require("express");
const bodyParser = require("body-parser");
const path = require('path');
const request = require('request');
const multer = require("multer");
const storage = multer.diskStorage({
    destination: (req, file, callback) => {
        callback(null, 'images');
    },
    filename: (req, file, callback) => {
        console.log(file);
        callback(null, Date.now() + path.extname(file.originalname));
    }

})
const upload = multer({ storage: storage });

let mysql = require("mysql");
const { json } = require("body-parser");

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

app.use(function (req, res, next) {
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
    res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
    res.setHeader('Access-Control-Allow-Credentials', true);
    next();
});

app.get('/testapi', (req, res) => {
    let query = 'SELECT name FROM vrestate.test WHERE id = ' + req.query.id;

    connection.query(query, (error, results, fields) => {
        if (error) {
            return console.error(error);
        }
        if (results.length == 0) {
            res.send('Kullanici Bulunamadi!');
        }
        else {
            res.send((req.query.id) + ' nolu id ye sahip kullanici ' + results[0].name);
            console.log(results[0].name)
        }

    });


});

app.get('/loaderio-0ea84b7e34801498d9390d93deb66294', (req, res) => {
    res.send('loaderio-0ea84b7e34801498d9390d93deb66294');
})

app.get('/apitest', (req, res) => {
    res.json({
        "keys": ["id"],
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
    res.writeHead(200, { 'Content-Type': 'text/html' });
    res.write('<form action="/upload" enctype="multipart/form-data" method="post">');
    res.write(' <input type="file" name="image" accept="image/*">');
    res.write('<input type="submit" value="Upload">');
    res.write('</form>');
    return res.end();
})

app.post('/upload', upload.single("image"), (req, res) => {
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
                if (err) throw err
                res.send({
                    message: "File Uploaded",
                    id: results[0].file_id
                });
            })
        })
    }
});

app.get('/getImage', (req, res) => {
    if (req.query.id == null || req.query.id == '') {
        res.status(400).send({ message: 'FileID can not be null' })
        return;
    }
    let query = 'select * from photos where file_id =' + req.query.id;
    connection.query(query, (error, results) => {
        if (error) {
            res.statusMessage = 'Database Query Error';
            res.status(500).send({ message: error });
            return;
        }
        if (results.length == 0) {
            res.send('Image Not Found');
            return;
        }
        res.sendFile('images/' + results[0].file_src, { root: '.' });
    })
})


app.get('/login/check', (req, res) => {
    let query = 'SELECT * FROM vrestate.user WHERE mail = \'' + req.query.mail + '\'';

    connection.query(query, (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error: ' + error;
            res.status(500).end();
            return console.error(error);
        }
        if (results.length == 0) {
            res.statusMessage = 'User Not Found';
            res.status(400).end();
        }
        else {
            res.send(results[0]);
        }

    });


});

app.get('/login/getById', (req, res) => {
    let query = 'SELECT * FROM vrestate.user WHERE id = \'' + req.query.id + '\'';

    connection.query(query, (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error: ' + error;
            res.status(500).end();
            return console.error(error);
        }
        if (results.length == 0) {
            res.statusMessage = 'User Not Found';
            res.status(400).end();
        }
        else {
            res.send(results[0]);
        }

    });


});

app.post('/login', (req, res) => {
    let query = 'SELECT * FROM vrestate.user WHERE mail = \'' + req.body.mail + '\'';

    connection.query(query, (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error: ' + error;
            res.status(500).end();
            return console.error(error);
        }
        if (results.length == 0) {
            let query2 = 'INSERT INTO user (id,name,surname,mail) values (\'' + req.body.id + '\',\'' + req.body.name + '\',\'' + req.body.surname + '\',\'' + req.body.mail + '\')';
            connection.query(query2, (error, results, fields) => {
                if (error) {
                    res.statusMessage = 'Database Query Error: ' + error;
                    res.status(500).end();
                    return console.error(error);
                }
                else {

                    res.status(200);
                    res.send('User Successfully Created!');
                }

            });
        }
        else {
            res.send(results[0]);
        }

    });


});

//girilmeyen değerleri apiye null gönderelim.
app.post('/estate/create', (req, res) => {
    let query = "INSERT INTO estate (title, head_photo_id, estate_type, category, price, create_date, last_update, location_ilce, location_il, coordX, coordY, room_type, m2, vr_id, owner_id) VALUES (?)"
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
    connection.query(query, [values], (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error';
            res.status(500).send({ message: error });
            return;
        }
        query = 'select * from estate order by 1 desc'
        connection.query(query, (error, results, fields) => {
            if (error) {
                res.statusMessage = 'Database Query Error';
                res.status(500).send({ message: error });
                return;
            }
            createdId = results[0].id;
            query = "INSERT INTO estate_detail (id, photo_ids, m2_brut, buildingAge, floors, buildingFloors, heatingSystem, balconyCount, bathroomCount, isFurnished, isBuildingComplex, buildingFees, complexName, isTradeable) VALUES (?)"
            values = [];
            values[values.length] = createdId;
            values[values.length] = req.body.photo_ids;
            values[values.length] = req.body.m2_brut;
            values[values.length] = req.body.buildingAge;
            values[values.length] = req.body.floors;
            values[values.length] = req.body.buildingFloors;
            values[values.length] = req.body.heatingSystem;
            values[values.length] = req.body.balconyCount;
            values[values.length] = req.body.bathroomCount;
            values[values.length] = req.body.isFurnished;
            values[values.length] = req.body.isBuildingComplex;
            values[values.length] = req.body.buildingFees;
            values[values.length] = req.body.complexName;
            values[values.length] = req.body.isTradeable;

            connection.query(query, [values], (error, results, fields) => {
                if (error) {
                    res.statusMessage = 'Database Query Error';
                    res.status(500).send({ message: error });
                    return;
                }
                res.status(200).send({ id: createdId, message: 'Estate Successfully Created' });
                return;
            })
        })

    })
});

app.post('/estate/update', (req, res) => {
    if (req.query.id == null || req.query.ownerId == null) {
        res.status(400).send({ message: "Params cannot be null" });
        return;
    }
    let values = [];
    values[values.length] = req.query.id
    values[values.length] = req.query.ownerId
    let query = 'select id from estate where id = ? and owner_id = ?';
    connection.query(query, values, (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error';
            res.status(500).send({ message: error });
            return;
        }
        if (results.length == 0) {
            res.status(400).send({ message: "No estate found to update" });
            return;
        }
        values = [];
        values[values.length] = req.body.title;
        values[values.length] = req.body.head_photo_id;
        values[values.length] = req.body.estate_type;
        values[values.length] = req.body.category;
        values[values.length] = req.body.price;
        let date = new Date().toISOString().substring(0, 10);
        values[values.length] = date;
        values[values.length] = req.body.ilce;
        values[values.length] = req.body.il;
        values[values.length] = req.body.coordX;
        values[values.length] = req.body.coordY;
        values[values.length] = req.body.room_type;
        values[values.length] = req.body.m2;
        values[values.length] = req.body.vr_id;
        values[values.length] = req.query.id;
        values[values.length] = req.query.ownerId;
        query = 'update estate set title = ?, head_photo_id = ?, estate_type = ?, category = ?, price = ?, last_update = ?, location_ilce = ?, location_il = ?, coordX = ?, coordY = ?, room_type = ?, m2 = ?, vr_id = ? where id = ? and owner_id = ?'
        connection.query(query, values, (error, results, fields) => {
            if (error) {
                res.statusMessage = 'Database Query Error';
                res.status(500).send({ message: error });
                return;
            }
            values = [];
            values[values.length] = req.body.photo_ids;
            values[values.length] = req.body.m2_brut;
            values[values.length] = req.body.buildingAge;
            values[values.length] = req.body.floors;
            values[values.length] = req.body.buildingFloors;
            values[values.length] = req.body.heatingSystem;
            values[values.length] = req.body.balconyCount;
            values[values.length] = req.body.bathroomCount;
            values[values.length] = req.body.isFurnished;
            values[values.length] = req.body.isBuildingComplex;
            values[values.length] = req.body.buildingFees;
            values[values.length] = req.body.complexName;
            values[values.length] = req.body.isTradeable;
            values[values.length] = req.query.id;
            query = 'update estate_detail set photo_ids = ?, m2_brut = ?, buildingAge = ?, floors = ?, buildingFloors = ?, heatingSystem = ?, balconyCount = ?, bathroomCount = ?, isFurnished = ?, isBuildingComplex = ?, buildingFees = ?, complexName = ?, isTradeable = ? where id = ?'
            connection.query(query, values, (error, results, fields) => {
                console.log(query)
                if (error) {
                    res.statusMessage = 'Database Query Error';
                    res.status(500).send({ message: error });
                    return;
                }
                res.status(200).send({ message: "Estate Successfully Updated" });
            })
        })
    })

});

app.post('/estate/delete', (req, res) => {
    if (req.query.id == null || req.query.ownerId == null) {
        res.status(400).send({ message: "Params cannot be null" });
        return;
    }
    let values = [];
    values[values.length] = req.query.id
    values[values.length] = req.query.ownerId
    let query = 'select id from estate where id = ? and owner_id = ?';
    connection.query(query, values, (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error';
            res.status(500).send({ message: error });
            return;
        }
        if (results.length == 0) {
            res.status(400).send({ message: "No estate found to delete" });
            return;
        }
        query = 'DELETE FROM estate_detail WHERE id = ' + req.query.id;
        connection.query(query, (error, results, fields) => {
            if (error) {
                res.statusMessage = 'Database Query Error';
                res.status(500).send({ message: error });
                return;
            }
            query = 'DELETE FROM estate WHERE id = ' + req.query.id;
            connection.query(query, (error, results, fields) => {
                if (error) {
                    res.statusMessage = 'Database Query Error';
                    res.status(500).send({ message: error });
                    return;
                }
                res.status(200).send({ message: "Estate Successfully Deleted" });
            })
        })
    })
});

app.get('/estate/getEstates', (req, res) => {
    let query = 'Select * from estate'
    if (req.query.searchFilter == 'true') {
        query = query + ' where'
        if (req.query.id != null || req.query.id != undefined) {
            query += ' id = ' + req.query.id + ' and';
        }

        if (req.query.title != null || req.query.title != undefined) {
            query += ' title like %' + req.query.title + '% and';
        }

        if (req.query.estate_type != null || req.query.estate_type != undefined) {
            query += ' estate_type = ' + req.query.estate_type + ' and';
        }

        if (req.query.category != null || req.query.category != undefined) {
            query += ' category = ' + req.query.category + ' and';
        }

        if (req.query.priceMin != null || req.query.priceMin != undefined) {
            query += ' price >= ' + req.query.priceMin + ' and';
        }

        if (req.query.priceMax != null || req.query.priceMax != undefined) {
            query += ' price <= ' + req.query.priceMax + ' and';
        }

        if (req.query.create_date != null || req.query.create_date != undefined) {//todo date min max
            //query+= ' id = '+req.query.id+' and';
        }

        if (req.query.location_il != null || req.query.location_il != undefined) {
            query += ' location_il = ' + req.query.location_il + ' and';
        }

        if (req.query.location_ilce != null || req.query.location_ilce != undefined) {
            query += ' location_ilce = ' + req.query.location_ilce + ' and';
        }

        if (req.query.room_type != null || req.query.room_type != undefined) {
            query += ' room_type = ' + req.query.room_type + ' and';
        }

        if (req.query.price != null || req.query.price != undefined) {//todo minmax
            //query+= ' id = '+req.query.id+' and';
        }
    }
    if (req.query.detail == 'true') {
        query += ' inner join estate_detail on estate.id = estate_detail.id'
    }
    console.log(query);
    connection.query(query, (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error';
            res.status(500).send({ message: error });
            return;
        }
        res.status(200).send({
            results
        })
    })
});

//json mu gidiyor control.
app.get('/checkLocation', (req, res) => {
    let ip = req.socket.remoteAddress.substring(req.socket.remoteAddress.indexOf(':', 2) + 1);
    request('http://ip-api.com/json/' + ip, (error, response, body) => {
        if (error) {
            res.status(400).send({ message: error });
            return;
        }
        res.send(body)
        //res.send({country:body.country,region:body.regionName});
    })

})

app.post('/unity/save', (req, res) => {
    if (req.query.id == null) {
        res.status(400).send({ message: 'ID cannot be null!' });
        return;
    }
    let query = 'select id from vr_model where id = ' + req.query.id;
    console.log(req.body)
    connection.query(query, (error, results, fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error';
            res.status(500).send({ message: error });
            return;
        }
        if (results.length == 0) {
            res.status(400).send({ message: 'VR model does not exist' });
            return;
        }
        query = 'update vr_model set model = ? where id = ' + req.query.id;
        let values = JSON.stringify(req.body);
        connection.query(query, values, (error, results, fields) => {
            if (error) {
                res.statusMessage = 'Database Query Error';
                res.status(500).send({ message: error });
                return;
            }
            res.status(200).send({ message: 'Model successfully saved.' })
        })
    })
})

app.get('/unity/load', (req, res) => {
    if (req.query.id == null) {
        res.status(400).send({ message: 'ID cannot be null!' });
        return;
    }
    let query = 'select * from vr_model where id = '+req.query.id;
    connection.query(query, (error,results,fields) => {
        if (error) {
            res.statusMessage = 'Database Query Error';
            res.status(500).send({ message: error });
            return;
        }
        if(results.length == 0){
            res.status(400).send({ message: 'VR model does not exist' });
            return;
        }
        let jsonReply = JSON.parse(results[0].model);
        res.status(200).json(jsonReply)
    })

})

app.listen(5002, () => {
    connection.connect(function (err) {
        if (err) {
            return console.error('error: ' + err.message);
        }

        console.log('Connected to the MySQL server.');
    });
    console.log('server started on port 5002');
});