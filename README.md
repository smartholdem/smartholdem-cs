# SmartHoldem Platform API C#

SmartHoldem-CS Client init
First call should be network selection, so all settings can initialize before going into action.

SmartHoldemNetApi.Instance.Start(NetworkType.MainNet); //Other types are TestNet
For additional settings please see settings file. To modify settings, just add settings.conf file to root folder. File can only include changed settings (not all).

Account/Wallet layer
var accCtnrl = new AccountController("top secret pass");
//Send STH
var result = accCtnrl.SendSTH(100, "Sa9JKodiNeM7tbYjxwEhvvG1kBczhQxTN3", "Test trans from Account",
                "pass phrase");
//Vote 4 Delegate                
var result = accCtnrl.VoteForDelegate( votes, "top secret pass");
Service layer
For a full list of available api calls please look at the SmartHoldem-CS Test project

//PeerService
var peers = PeerService.GetAll();
var peersOK = peers.Where(x => x.Status.Equals("OK"));

//TransactionService
var trans = TransactionService.GetAll();
...
Core Layer
Layer is used for core SmartHoldem blockchain communication (transaction, crypto...). It is wrapped by api libraries that are called from the service and Account layer.

TransactionApi tx = TransactionApi.CreateTransaction(recepient, amount, description, passphrase);
Peer peer = Network.Mainnet.GetRandomPeer();
var result = peer.PostTransaction(tx);    