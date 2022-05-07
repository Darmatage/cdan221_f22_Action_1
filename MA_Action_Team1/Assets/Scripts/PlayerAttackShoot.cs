using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackShoot : MonoBehaviour{

	public Animator animator;
	public Transform firePoint;
	public Transform firePointUp;
	public Transform firePointDown;
	
	public GameObject projectileFire;
	public float projectileSpeedFire = 10f;
	public float attackRateFire = 2f;
	private float nextAttackTimeFire = 0f;
	
	public GameObject projectileIce;
	public float projectileSpeedIce = 10f;
	public float attackRateIce = 2f;
	private float nextAttackTimeIce = 0f;
	
	Vector2 fwd;

	void Start(){
           animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update(){
		
		string direction = GetComponent<PlayerMoveAround>().currentDirection;
		if (direction == "front"){
			fwd = (firePoint.position - this.transform.position).normalized;
		} else if (direction == "up"){
			fwd = (firePointUp.position - firePoint.position).normalized;
		} else if (direction == "down"){
			fwd = (firePointDown.position - firePoint.position).normalized;
		}
		
		if (Time.time >= nextAttackTimeFire){
			if (Input.GetAxis("AttackFire") > 0){
				playerFireAttack();
				nextAttackTimeFire = Time.time + 1f / attackRateFire;
			}
		}
		
		if (Time.time >= nextAttackTimeIce){
			if (Input.GetAxis("AttackIce") > 0){
				playerIceAttack();
				nextAttackTimeIce = Time.time + 1f / attackRateIce;
			}
		}
		
	}

	void playerFireAttack(){
		animator.SetTrigger("Shoot");
		//Vector2 fwd = (firePoint.position - this.transform.position).normalized;
		GameObject projectile = Instantiate(projectileFire, firePoint.position, Quaternion.identity);
		projectile.GetComponent<Rigidbody2D>().AddForce(fwd * projectileSpeedFire, ForceMode2D.Impulse);
	}
	
	void playerIceAttack(){
		animator.SetTrigger("Shoot");
		//Vector2 fwd = (firePoint.position - this.transform.position).normalized;
		GameObject projectile = Instantiate(projectileIce, firePoint.position, Quaternion.identity);
		projectile.GetComponent<Rigidbody2D>().AddForce(fwd * projectileSpeedIce, ForceMode2D.Impulse);
	}
	
}
