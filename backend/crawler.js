const axios = require("axios");
const cheerio = require("cheerio");
const httpsProxyAgent = require('https-proxy-agent');
const socksAgent = new httpsProxyAgent('socks://bora:Bobbob117@185.254.239.84:80');
let mysql = require("mysql");
let connection = mysql.createConnection({
    host: 'vrestate.clbfq7mnbhip.eu-west-3.rds.amazonaws.com',
    port: '3306',
    user: 'admin',
    password: 'VRestate123**',
    database: 'vrestate'
});

async function main() {
    connection.connect(function (err) {
        if (err) {
            return console.error('error: ' + err.message);
        }

        console.log('Connected to the MySQL server.');
    });
    let pageHTMLS = [await axios.get("https://www.hepsiemlak.com/emlak", { httpAgent: socksAgent, httpsAgent: socksAgent }), await axios.get("https://www.hepsiemlak.com/emlak?page=2", { httpAgent: socksAgent, httpsAgent: socksAgent }), await axios.get("https://www.hepsiemlak.com/emlak?page=3", { httpAgent: socksAgent, httpsAgent: socksAgent }), await axios.get("https://www.hepsiemlak.com/emlak?page=4", { httpAgent: socksAgent, httpsAgent: socksAgent }), await axios.get("https://www.hepsiemlak.com/emlak?page=5", { httpAgent: socksAgent, httpsAgent: socksAgent })];
    let productURLS = [];
    console.log('asd')
    for (let i = 0; i < 3; i++) {
        const $ = cheerio.load(pageHTMLS[i].data);

        $("a.card-link").each((index, element) => {
            if ($(element).attr('href').indexOf('/daire') > -1 && $(element).attr('href').indexOf('gunluk') == -1)
                productURLS.push("https://www.hepsiemlak.com" + $(element).attr('href'));;
        })
    }
    console.log(productURLS);
    pageHTMLS = [];
    for (let i = 0; i < productURLS.length; i++) {
        pageHTMLS.push(await axios.get(productURLS[i], { httpAgent: socksAgent, httpsAgent: socksAgent }));
        console.log(i)
    }
    for (let i = 0; i < pageHTMLS.length; i++) {
        const $ = cheerio.load(pageHTMLS[i].data);
        let currentEstate = {
            id: 0,
            title: "",
            head_photo_url: "",
            url: "",
            estate_type: "",
            category: "",
            price: 0,
            createDate: "",
            location_ilce: "",
            location_il: "",
            coordX: 0,
            coordY: 0,
            room_type: "",
            m2: 0,
            vr_id: 0,

        }
        let specs = [];
        $("div.left h1.fontRB").each((index, element) => {
            specs.push(($(element).text().replace(/\s\s+/g, ' ').substring(1)))
        })
        $("p.price").each((index, element) => {
            specs.push(($(element).text().replaceAll('\n', '')).replaceAll(' ', ''))
        })

        $("img").each((index, element) => {
            if ((($(element).attr('src')).indexOf('hecdn01.hemlak.com/mncropresize')) > 0) {
                specs.push($(element).attr('src'))
                return false;
            }

        })
        $("li.spec-item span.txt").each((index, element) => {
            specs.push($(element).next().text())
        })
        $("ul.short-info-list li").each((index, element) => {
            specs.push(($(element).text()))
            specs.push(($(element).next().text()))
            return false;
        })
        console.log(specs)
        let values = [];
        currentEstate.id = parseInt(specs[3].replace('-', ''));
        values[values.length] = parseInt(specs[3].replace('-', ''))
        currentEstate.title = specs[0];
        values[values.length] = specs[0];
        currentEstate.head_photo_url = specs[2];
        values[values.length] = specs[2];
        currentEstate.estate_type = specs[5];
        values[values.length] = specs[5];
        currentEstate.category = specs[6];
        values[values.length] = specs[6];
        currentEstate.price = parseInt(specs[1].replaceAll('.', '').replace('TL', ''));
        values[values.length] = parseInt(specs[1].replaceAll('.', '').replace('TL', ''));
        currentEstate.createDate = specs[4].substring(6, 10) + '-' + specs[4].substring(3, 5) + '-' + specs[4].substring(0, 2);
        values[values.length] = specs[4].substring(6, 10) + '-' + specs[4].substring(3, 5) + '-' + specs[4].substring(0, 2);
        currentEstate.location_ilce = specs[specs.length - 1].replace(/\s\s+/g, ' ').replaceAll(' ', '');
        values[values.length] = specs[specs.length - 1].replace(/\s\s+/g, ' ').replaceAll(' ', '');
        currentEstate.location_il = specs[specs.length - 2].replace(/\s\s+/g, ' ').replaceAll(' ', '');
        values[values.length] = specs[specs.length - 2].replace(/\s\s+/g, ' ').replaceAll(' ', '');
        currentEstate.coordX = null
        values[values.length] = null
        currentEstate.coordY = null
        values[values.length] = null
        currentEstate.room_type = (specs[7].replaceAll(' ', ''));
        values[values.length] = (specs[7].replaceAll(' ', ''));
        currentEstate.m2 = parseInt(specs[8].replace(/\s\s+/g, ' ').replaceAll(' ', '').replace('m2', ''));
        values[values.length] = parseInt(specs[8].replace(/\s\s+/g, ' ').replaceAll(' ', '').replace('m2', ''));
        let response = await axios.post("http://vrestate.tech:5002/unity/assignId", {
            httpAgent: socksAgent,
            httpsAgent: socksAgent,
        });
        let returnedData = response.data;
        console.log(returnedData);
        let vrid = returnedData.id;
        currentEstate.vr_id = vrid
        values[values.length] = vrid
        currentEstate.url = productURLS[i];
        values[values.length] = productURLS[i];

        let query = 'insert into hepsi_estate(id,title,head_photo_url,estate_type,category,price,create_date,location_ilce,location_il,coordX,coordY,room_type,m2,vr_id,url) values (?)';
        await connection.query(query, [values], (error, results, fields) => {
            if (error) {
                console.log(error)
                return;
            }
            console.log(currentEstate.id + ' is successfully added to db!');
        })
    }
}

main()
    .then(() => {
        // successful ending 
        process.exit(0);
    })
    .catch((e) => {
        // logging the error message 
        console.error(e);

        // unsuccessful ending 
        process.exit(1);
    });