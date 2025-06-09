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
import com.alvin.d2_modul2.model.User
import com.alvin.d2_modul2.repository.AuthRepository
import com.google.android.material.textfield.TextInputEditText
import org.json.JSONObject
import kotlin.concurrent.thread

class LoginScreen : AppCompatActivity() {

    private lateinit var etEmail: TextInputEditText
    private lateinit var etPassword: TextInputEditText
    private lateinit var bLogin: Button
    private lateinit var linkToRegister: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login_screen)

        etEmail = findViewById(R.id.etLoginEmail)
        etPassword = findViewById(R.id.etLoginPassword)
        bLogin = findViewById(R.id.bLogin)
        linkToRegister = findViewById(R.id.linkToRegister)

        bLogin.setOnClickListener {
            val email = etEmail.text.toString()
            val password = etPassword.text.toString()

            if (email.isEmpty() || password.isEmpty()) {
                Toast.makeText(this@LoginScreen, "Please fill all fields!", Toast.LENGTH_SHORT).show()
            } else {
                doLogin(email, password)
            }
        }

        linkToRegister.setOnClickListener {
            Intent(this@LoginScreen, RegisterScreen::class.java).also {
                startActivity(it)
            }
        }

    }

    private fun doLogin(email: String, password: String) {
        thread {
            val response = AuthRepository.login(
                email = email,
                password = password
            )
            try {
                if (response.isNotEmpty()) {
                    val jsonObject = JSONObject(response)
                    val data = jsonObject.getJSONObject("data")
                    val loggedUser = User(
                        id = data.getInt("id"),
                        pictureUri = data.getString("profilePicture"),
                        fullName = data.getString("fullname"),
                        email = data.getString("email"),
                        phoneNumber = data.getString("phoneNumber"),
                        role = data.getString("role")
                    )
                    runOnUiThread {
                        Intent(this@LoginScreen, ContainerActivity::class.java).also {
                            it.putExtra("USER", loggedUser)
                            startActivity(it)
                        }
                        Toast.makeText(this@LoginScreen, "Success Login", Toast.LENGTH_SHORT).show()
                        finish()
                    }
                }
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
    }

}
