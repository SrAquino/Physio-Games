using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Globalization;

public class Player_galaxy : MonoBehaviour{
    //public Transform aimTarget; //alvo para onde a bolinha será lançada para o lado do bot
    
    float speed = 5.0f;      //velocidade de movimentação do player

    public float fireRate = 0.7f;
    public float canFire = 0.0f;

    public bool powerShoot = false;
    public bool powerSpeed = false;
    public bool powerShield = false;

    public static int Life = 3;

    [SerializeField]// Variavel privada mas pode ser modificada no unity
    private GameObject NormalLaser;

    [SerializeField]
    private GameObject ExplosionPrefab;
    
    [SerializeField]
    private GameObject ShieldGameObject;

    public static bool flagDificuldade;
    public static int numAcertos;
    float deslocamentoAnterior = -1.0f;

    private controllGame2 _gerenciadordeinterface;

   
    void Start()
    {
        transform.position = new Vector3(0.0f, -3.0f, 0.0f);    //Inicia a posição do player
        numAcertos = -1;
        
        _gerenciadordeinterface = GameObject.Find("controllGame").GetComponent<controllGame2>();
        if(_gerenciadordeinterface != null){
            _gerenciadordeinterface.atualizaVida(0);
        }
    }

    // void FixedUpdate()
    void Update()
    {
        //Movimentação
        //movimentaUsandoTeclado();   //Para desenvolvimento inicial e testes
        movimentaUsandoCelular_v2();   

        //Tiros
        Shooting();

    }

//Sistema de movimentação desenvolvido pela Andrelise
    void movimentaUsandoCelular(){
        if(configCalibragem.porta.IsOpen){
            try{
                if(configCalibragem.porta.BytesToRead == 0){ //Não está sendo recebido dados no buffer
                    //Debug.Log(porta.BytesToRead);
                    //Debug.Log("Sem recebimento de dados B!");
                 }else{
                    //Trecho comentado que funciona apenas quando enviado APENAS UM BYTE
                    //int dadoNoSensor = configCalibragem.porta.ReadByte();
                    //configCalibragem.porta.DiscardInBuffer();
                    //configCalibragem.porta.Write("2");

                    //Debug.Log("Recebimento de dados B!");

                    //Trecho de código para coletar o que é recebido pela Unity quando é solicitado valores de movimento
                    string dadoNoSensor = configCalibragem.porta.ReadTo("\n");
                    configCalibragem.porta.DiscardInBuffer();

                    configCalibragem.porta.Write("2");
                    configCalibragem.porta.DiscardOutBuffer();

                    //Debug.Log("Valor recebido: " + dadoNoSensor);
                    //Debug.Log("Tamanho: " + dadoNoSensor.Length);

                    //verifica se não houve um erro de leitura do buffer e leu vazio
                    if(dadoNoSensor != "" && (dadoNoSensor.Length == 4 || dadoNoSensor.Length == 7)){
                        //realiza a separação dos valores de direção e posição recebidos do nó sensor
                        string[] separandoDados = dadoNoSensor.Split(';');

                        string direcao = separandoDados[0]; 
                        float posicao = 0f;
                        
                        //lê dados de posição recebidos do nó sensor - direita e esquerda apenas 
                        if(direcao == "E" || direcao == "D"){
                            posicao = float.Parse(separandoDados[1], CultureInfo.InvariantCulture);
                            
                            //gerar posição negativa quando a direção é para a esquerda
                            //pq o app flutter envia os valores em módulo, sempre positivo
                            if(direcao == "E"){
                                posicao = posicao * (-1.0f);
                            }
                        }
                        
                        //moveAvatar(direcao, posicao);

                        float x = transform.position.x;
                        //Debug.Log("Posição atual do avatar em z é igual a: " + z);
                        
                        if(deslocamentoAnterior == posicao){
                            //Debug.Log("Valor repetido recebido!");
                        }else{

                            float deslocamento = 0.0f;

                            if(x == 0 || (x > -1 && x < 1)){
                                deslocamento = x + posicao;
                            }else if(posicao > x){
                                deslocamento = posicao - x;
                            }else if(x > posicao){
                                deslocamento = x - posicao;
                            }
                            
                            deslocamentoAnterior = deslocamento;

                            // Debug.Log("Nova posição igual a: " + deslocamento);

                            //Faz o módulo do deslocamento para realizar corretamente a movimentação no eixo z
                            if(deslocamento < 0){
                                deslocamento = deslocamento * (-1.0f);
                            }

                            float VoandoEspaco = 0.0f;

                            if(direcao == "D"){
                                while(VoandoEspaco < deslocamento && transform.position.x <= 8f){ 
                                    // Debug.Log(1 * speed * Time.deltaTime);
                                    transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0 );
                                    VoandoEspaco += (1 * speed * Time.deltaTime);
                                    if (transform.position.x > 7.5f){
                                        transform.position = new Vector3(7.5f, transform.position.y, 0);
                                    } 
                                }
                            }else if(direcao == "E"){
                                while(VoandoEspaco < deslocamento && transform.position.x >= (-8f)){
                                    // Debug.Log(-1 * speed * Time.deltaTime);
                                    transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
                                    VoandoEspaco += (1 * speed * Time.deltaTime);
                                    if (transform.position.x < -7.5f) {
                                        transform.position = new Vector3(-7.5f, transform.position.y, 0);
                                    } 
                                }
                            }else if(direcao == "P"){
                                // transform.position += new Vector3(0, 0, 0);
                            }
                        }
                    }
                }
            }catch(System.Exception){
                throw;
            }
        }
    }

//Sistema de movimentação desenvolvido pelo Douglas
    void movimentaUsandoCelular_v2(){
        //Debug.Log("- - - - movimento v2 - - - - -");
        //int cd = 0;

        if(configCalibragem.porta.IsOpen){
            try{
                if(configCalibragem.porta.BytesToRead != 0){
                    string dadoNoSensor = configCalibragem.porta.ReadTo("\n");
                    configCalibragem.porta.DiscardInBuffer();

                    configCalibragem.porta.Write("2");
                    configCalibragem.porta.DiscardOutBuffer();

                    //verifica se não houve um erro de leitura do buffer e leu vazio
                    if(dadoNoSensor != "" && (dadoNoSensor.Length == 4 || dadoNoSensor.Length == 7)){
                        //realiza a separação dos valores de direção e posição recebidos do nó sensor
                        string[] separandoDados = dadoNoSensor.Split(';');

                        string direcao = separandoDados[0]; 
                        float posicao = 0f;
                        
                        //lê dados de posição recebidos do nó sensor - direita e esquerda apenas 
                        if(direcao == "E" || direcao == "D"){
                            posicao = float.Parse(separandoDados[1], CultureInfo.InvariantCulture);
                            
                            //gerar posição negativa quando a direção é para a esquerda
                            //pq o app flutter envia os valores em módulo, sempre positivo
                            if(direcao == "E"){
                                posicao = posicao * (-1.0f);
                            }
                        }

                        float x = transform.position.x;
                        
                        if(deslocamentoAnterior != posicao){

                            float deslocamento = 0.0f;

                            if(x > -1 && x < 1){
                                deslocamento = x + posicao;
                            }else if(posicao > x){
                                deslocamento = posicao - x;
                            }else if(x > posicao){
                                deslocamento = x - posicao;
                            }
                            
                            deslocamentoAnterior = deslocamento;

                            //Faz o módulo do deslocamento para realizar corretamente a movimentação no eixo x
                            if(deslocamento < 0){
                                deslocamento = deslocamento * (-1.0f);
                            }

                            float VoandoEspaco = 0.0f;

                            if(direcao == "D"){
                                while(VoandoEspaco < deslocamento){
                                    //cd++;
                                    //Debug.Log("contador da direita: "+cd); 
                                    //transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0 );
                                    transform.Translate(Vector3.right * Time.deltaTime * speed * 0.1f);
                                    VoandoEspaco += (1 * speed * Time.deltaTime);
                                    
                                    if (transform.position.x > 7.5f){
                                        transform.position = new Vector3(7.5f, transform.position.y, 0);
                                    } 
                                }
                            }else if(direcao == "E"){
                                while(VoandoEspaco < deslocamento){
                                    //transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
                                    transform.Translate(Vector3.right * Time.deltaTime * speed * -0.1f);
                                    VoandoEspaco += (1 * speed * Time.deltaTime);
                                    
                                    if (transform.position.x < -7.5f) {
                                        transform.position = new Vector3(-7.5f, transform.position.y, 0);
                                    } 
                                }
                            }else if(direcao == "P"){}
                        }
                    }
                }
            }catch(System.Exception){
                throw;
            }
        }
    }

    //função para mover o avatar usando como entrada de dados o teclado
    void movimentaUsandoTeclado(){
        float horizontalInput = Input.GetAxis("Horizontal");//Recebe dado do teclado Setas ou A e D
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //Limita o player a se movimentar entre -7,5 e 7,5
        if(transform.position.x > 7.5){
            transform.position = new Vector3(7.5f, transform.position.y, 0);
        }
        if(transform.position.x < -7.5){
            transform.position = new Vector3(-7.5f, transform.position.y, 0);
        }//Fim limitador do player

        //Aumenta a velocidade quando coletar um powerup
        if (powerSpeed){
            transform.Translate(Vector3.right * Time.deltaTime * (speed*2) * horizontalInput);
        }

    }

    private void Shooting(){
        if(Time.time > canFire){

            if (powerShoot){
                 Instantiate(NormalLaser, transform.position + new Vector3(-0.55f,0,0), Quaternion.identity);
                 Instantiate(NormalLaser, transform.position + new Vector3(0.55f,0,0), Quaternion.identity);
                 
            }
            // Input.GetKeyDown(KeyCode.Space)
            // Sempre que apertar espaço um novo objeto é instanciado
            //          (O objeto, O local, );
                Instantiate(NormalLaser, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
            //          (Marco quem é o objeto a ser instanciado la no unity)
            //          (transform.position retorna a posição atual do player)
            //          (Quaternion = )

                canFire = fireRate + Time.time;
                //Atira denovo depois do tempo de cooldown
        }
    }

    public void Damage(){

        if(powerShield == true){
            //Debug.Log("Colidiu com escudo ativado!");
            powerShield = false;    //Desativa o escudo
            ShieldGameObject.SetActive(false);
        return;
        } 

        Life--;
        _gerenciadordeinterface.atualizaVida(Life);

        if(Life == 0){
            Destroy(this.gameObject);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        }
    }

     public void powerUpOn(string power){
        switch(power){
            case "triple":
                powerShoot = true;
                StartCoroutine(PowerDownRotine("triple"));
            break;

            case "speed":
                powerSpeed = true;
                StartCoroutine(PowerDownRotine("speed"));
            break;

            case "shield":
                powerShield = true;
                ShieldGameObject.SetActive(true);
                StartCoroutine(PowerDownRotine("shield"));
            break;
        }
    }
    
    IEnumerator PowerDownRotine(string power){
        yield return new WaitForSeconds(5.0f);

        switch(power){
            case "triple":
                powerShoot = false;
            break;

            case "speed":
                powerSpeed = false;
            break;

            case "shield":
                //powerShield = false;
            break;
        }
    } 

}
