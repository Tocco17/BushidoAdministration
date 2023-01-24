export const localStoragePlugin = {
    read(key) {
        if(typeof(key) != 'string'){
            console.error(`ERRORE NELLA LETTURA DA LOCAL STORAGE:`)
            console.error(`La chiave ${key} è di tipo ${typeof(key)}: dev'essere di tipo string`)
        }

        const hasPoints = key.includes('.')
        const keys = key.split('.')
        const mainKey = key.includes('.') ? keys.shift() : key
        const mainObject = JSON.parse(localStorage.getItem(mainKey))


        if(!mainObject){
            console.warn('ATTENZIONE NELLA LETTURA DA LOCAL STORAGE')
            console.warn(`La chiave ${key} non ha dato alcun risultato`)
        }    
        
        let result = mainObject 

        if(hasPoints){
            result = keys.reduce((res, k) => {
                if(!res[k]){
                    console.error('ERRORE NELLA LETTURA DA LOCAL STORAGE')
                    console.error("L'oggetto principale non ha la proprietà inserita")
                    console.error(`Chiave: ${key}`)
                    console.table(mainObject)
                }

                return res[k]
            }, mainObject)
        }

        return result
    },
    write(toBeSaved) {
        for (key in toBeSaved) {
            this.write(key, toBeSaved[key])
        }
    },
    write(key, value) {
        if(typeof(key) != 'string' ){
            console.error(`ERRORE NEL SALVATAGGIO IN LOCAL STORAGE:`)
            console.error(`La chiave è di tipo ${typeof(key)}: deve essere una stringa`)
            return
        }
        
        if(key.includes('.')){
            console.error(`ERRORE NEL SALVATAGGIO IN LOCAL STORAGE:`)
            console.error(`${key} non accettabile: contiene punti, deve essere una parola singola`)
            return
        }

        localStorage.setItem(key, JSON.stringify(value))
    },
    isStored(key) {
        return !!this.read(key)
    },
}