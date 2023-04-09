using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseAnim : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		

		float timer = 0f; 

	    float timerMax = 10f;

		bool collisionhappened = false;

		bool cooldownend = true;
  

		void Start()
		{
			open = false;
		}
        private void Update()
        {

			if (collisionhappened)
			{
				timer += Time.deltaTime;


				if (timer >= timerMax)
				{
					//Debug.Log("timerMax reached !");
					
					collisionhappened = false;
					timer = 0f;
					cooldownend = true;


				}
			}
		}

        private void OnTriggerEnter(Collider other)
		{
			Debug.Log("TRIGGER "  + other.gameObject.name);
			if ((other.gameObject.name== "InputModel" || other.gameObject.name == "ExampleAvatar") && cooldownend ==true) 
			{
				collisionhappened = true;
				if (open == false)
				{
					
				    StartCoroutine(opening());
					//this.gameObject.transform.localScale = new Vector3(0.4f, 1f, 1f);
					float objrotation = this.gameObject.transform.parent.gameObject.transform.localRotation.eulerAngles.y;
					//Debug.Log(objrotation + "openrot");
                    if (objrotation == 0f)
                    {
						this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x - 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z + 0.088f);
					}
					else if(objrotation == 180f)
					{
						this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x - 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z - 0.088f);
					}
					else if (objrotation == 90f)
					{
						this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x - 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z - 0.088f);
					}
					else if (objrotation == 270f)
					{
						this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x - 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z + 0.088f);
					}
	                cooldownend = false;


				}
				else
				{
					if (open == true)
					{
						
					    StartCoroutine(closing());
						//this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
						float objrotation = this.gameObject.transform.parent.gameObject.transform.localRotation.eulerAngles.y;
						//Debug.Log(objrotation + "closerot");
						if (objrotation == 0f) {
							this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z - 0.088f);
						}
						else if(objrotation== 180f)
                        {
							this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z + 0.088f);
						}
						else if (objrotation == 90f)
						{
							this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z + 0.088f);
						}
						else if (objrotation == 270f)
						{
							this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + 0.02f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z - 0.088f);
						}

						cooldownend = false;

					}

				}
			}

			
		}

		
		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
