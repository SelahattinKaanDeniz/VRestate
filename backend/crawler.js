const axios = require("axios");
const cheerio = require("cheerio");

async function main() {
    const pageHTMLS = [await axios.get("https://www.hepsiemlak.com/emlak"), await axios.get("https://www.hepsiemlak.com/emlak?page=2"), await axios.get("https://www.hepsiemlak.com/emlak?page=3")];
    const productURLS = [];
    console.log('asd')
    for (let i = 0; i < 3; i++) {
        const $ = cheerio.load(pageHTMLS[i].data);

        $("a.card-link").each((index, element) => {
            productURLS.push("https://www.hepsiemlak.com" + $(element).attr('href'));;
        })
    }
    console.log(productURLS);
    pageHTMLS = [];
    for(let i = 0; i<productURLS.length; i++){
        pageHTMLS.push(await axios.get(productURLS[i]));
    }
    for(let i = 0; i<pageHTMLS.length; i++){
        const $ = cheerio.load(pageHTMLS[i].data);
        let currentEstate = {
            title:"",
            
        }
        $("a.card-link").each((index, element) => {
            productURLS.push("https://www.hepsiemlak.com" + $(element).attr('href'));;
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