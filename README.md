# Controllo del Demanio Pubblico
Il presente applicativo ottiene ed elabora i dati della consistenza e valore del patrimonio immobiliare dello Stato in 
gestione all’Agenzia del Demanio sull'intero territorio nazionale. Questi dati sono disponibili per ogni provincia italiana, e sono divisi in tre categorie:
- **Patrimonio Disponibile**, beni gestiti con norme privatistiche.
- **Patrimonio Indisponibile**, beni destinati a scopi pubblici.
- **Demanio Storico Artistico**, beni sottoposti a vincolo storico, archeologico, artistico e culturale.

## Servizi Disponibili
È possibile consultare i vari servizi tramite browser utilizzando l'interfaccia grafica. Si possono consultare:
- Tutti i dati disponibili per tutte le provincie e le categorie.
- Visualizzare i dati di una certa provincia.
- Ottenere il valore totale dei beni per ogni provincia.

### Servizio SOAP
Inoltre, è stato implementato un servizio SOAP e il relativo file wsdl è disponibile all'url `/ServiceDemanio.wsdl`. 
Grazie a ciò è possibile richiamare tutti i dati del demanio e eventualmente filtrarli per provincia, restituindoli come xml.

## Conteinerizzazione dell'Applicativo
Viene utilizzata una tecnologia Docker grazie al quale è possibile conteinerizzare l'applicazione e i suoi servizi. 
  
## Componenti del Gruppo
Questo progetto di Cloud computing è stato realizzato dal gruppo composto da Della Roscia Giorgio, Di Lucchio Daniela, Di Spigno Mattia.
