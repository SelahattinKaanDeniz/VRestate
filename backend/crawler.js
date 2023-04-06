const axios = require("axios");
const cheerio = require("cheerio");
const fs = require("fs");

async function main() {
    const pageHTMLS = [await axios.get("https://www.hepsiemlak.com/emlak"),await axios.get("https://www.hepsiemlak.com/emlak"),await axios.get("https://www.hepsiemlak.com/emlak")];
    
    console.log('asd')
    const $ = cheerio.load(pageHTML.data);
    fs.writeFileSync('html.txt', pageHTML.data, err => {
        if(err){
            console.log(error);
        }
    })
    
    $("a.card-link").each((index, element) => {
        const productURL = "https://www.hepsiemlak.com" + $(element).attr('href');
        console.log(productURL);
    })
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