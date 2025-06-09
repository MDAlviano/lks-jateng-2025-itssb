package com.alvin.d2_modul2.ui.activity

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.alvin.d2_modul2.R
import com.alvin.d2_modul2.repository.AuthRepository
import com.google.android.material.textfield.TextInputEditText
import kotlin.concurrent.thread

class RegisterScreen : AppCompatActivity() {

    private lateinit var etFullName: TextInputEditText
    private lateinit var etEmail: TextInputEditText
    private lateinit var etPhone: TextInputEditText
    private lateinit var etPass: TextInputEditText
    private lateinit var etConfirmPass: TextInputEditText
    private lateinit var bRegister: Button
    private lateinit var linkToLogin: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_register_screen)

        initializeComponent()
        onClickHandle()

    }

    private fun initializeComponent() {
        etFullName = findViewById(R.id.etRegFullName)
        etEmail = findViewById(R.id.etRegEmail)
        etPhone = findViewById(R.id.etRegPhone)
        etPass = findViewById(R.id.etRegPass)
        etConfirmPass = findViewById(R.id.etRegConfirmPass)
        bRegister = findViewById(R.id.bRegister)
        linkToLogin = findViewById(R.id.linkToLogin)
    }

    private fun onClickHandle() {
        bRegister.setOnClickListener {
            val fullName = etFullName.text.toString()
            val email = etEmail.text.toString()
            val phone = etPhone.text.toString()
            val pass = etPass.text.toString()
            val confirmPass = etConfirmPass.text.toString()

            if (fullName.isNotEmpty() && email.isNotEmpty() && phone.isNotEmpty() && pass.isNotEmpty() && confirmPass.isNotEmpty()) {
                if (pass == confirmPass) {
                    doRegister(fullName, email, phone, pass, confirmPass)
                } else {
                    Toast.makeText(this@RegisterScreen, "Password and confirm password must be same!", Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(this@RegisterScreen, "Please fill all fields!", Toast.LENGTH_SHORT).show()
            }
        }

        linkToLogin.setOnClickListener {
            startActivity(Intent(this@RegisterScreen, LoginScreen::class.java))
            finish()
        }
    }

    private fun doRegister(
        fullName: String,
        email: String,
        phone: String,
        pass: String,
        confirmPass: String
    ) {
        thread {
            bRegister.isEnabled = false
            val response = AuthRepository.register(
                fullName = fullName,
                email = email,
                phoneNumber = phone,
                password = pass,
                confirmPassword = confirmPass
            )

            try {
                if (response.isNotEmpty()) {
                    runOnUiThread {
                        Intent(this@RegisterScreen, LoginScreen::class.java).also {
                            startActivity(it)
                        }

                        Toast.makeText(this@RegisterScreen, "Success register new account", Toast.LENGTH_SHORT).show()
                        finish()

                        bRegister.isEnabled = true
                    }
                }
            } catch (e: Exception) {
                e.printStackTrace()

                bRegister.isEnabled = true
            }
        }
    }
}