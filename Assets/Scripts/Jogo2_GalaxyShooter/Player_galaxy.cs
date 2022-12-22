using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Globalization;

public class Player_galaxy : MonoBehaviour{
    //public Transform aimTarget; //alvo para onde a bolinha será lançada para o lado do bot
    
    float speed = 15f;      //velocidade de movimentação do player

    public float fireRate = 0.7f;
    public float canFire = 0.0f;

    public bool powerShoot = false;
    public bool powerSpeed = false;
    public bool powerShield = false;

    private int Life = 1;

    [SerializeField]// Variavel privada mas pode ser modificada no unity
    private GameObject NormalLaser;

    [SerializeField]
    private GameObject ExplosionPrefab;
    
    [SerializeField]
    private GameObject ShieldGameObject;
    

    //float force = 30; //15
    bool hitting;

    //public Transform ball;
    //public Rigidbody playerRb;

    Vector3 aimTargetPosition;

    //posição aleatoria de rebate da bolinha 
    public Transform[] targets;

    //Comunicação serial
    //SerialPort porta;

    public static bool flagDificuldade;
    public static int numAcertos;
    float deslocamentoAnterior = -1.0f;

   
    void Start()
    {
        transform.position = new Vector3(0.0f, -3.0f, 0.0f);    //Inicia a posição do player
        numAcertos = -1;
    }

    // void FixedUpdate()
    void Update()
    {
        //Movimentação
        movimentaUsandoTeclado();   //Para desenvolvimento inicial e testes
        //movimentaUsandoCelular();   

        //Tiros
        Shooting();

        //Dano e Morte

    }

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

                    Debug.Log("Recebimento de dados B!");

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

                        float z = transform.position.z;
                        //Debug.Log("Posição atual do avatar em z é igual a: " + z);
                        
                        if(deslocamentoAnterior == posicao){
                            //Debug.Log("Valor repetido recebido!");
                        }else{

                            float deslocamento = 0.0f;

                            if(z == 0 || (z > -1 && z < 1)){
                                deslocamento = z + posicao;
                            }else if(posicao > z){
                                deslocamento = posicao - z;
                            }else if(z > posicao){
                                deslocamento = z - posicao;
                            }
                            
                            deslocamentoAnterior = deslocamento;

                            // Debug.Log("Nova posição igual a: " + deslocamento);

                            //Faz o módulo do deslocamento para realizar corretamente a movimentação no eixo z
                            if(deslocamento < 0){
                                deslocamento = deslocamento * (-1.0f);
                            }

                            float andandoMesa = 0.0f;

                            if(direcao == "D"){
                                while(andandoMesa < deslocamento && transform.position.z <= 8f){ 
                                    // Debug.Log(1 * speed * Time.deltaTime);
                                    transform.position += new Vector3(0, 0, 1 * speed * Time.deltaTime);
                                    andandoMesa += (1 * speed * Time.deltaTime);
                                    if (transform.position.x > 7.5f){
                                        transform.position = new Vector3(7.5f, transform.position.y, 0);
                                    } 
                                }
                            }else if(direcao == "E"){
                                while(andandoMesa < deslocamento && transform.position.z >= (-8f)){
                                    // Debug.Log(-1 * speed * Time.deltaTime);
                                    transform.position += new Vector3(0, 0, -1 * speed * Time.deltaTime);
                                    andandoMesa += (1 * speed * Time.deltaTime);
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
