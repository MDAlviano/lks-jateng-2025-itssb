package com.alvin.d2_modul2.ui.auth

import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import com.alvin.d2_modul2.model.User
import com.alvin.d2_modul2.repository.AuthRepository
import com.alvin.d2_modul2.session.SessionManager
import com.alvin.d2_modul2.ui.main.ContainerActivity
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

        setupView()
        setupListener()

    }

    private fun setupView() {
        etEmail = findViewById(R.id.etLoginEmail)
        etPassword = findViewById(R.id.etLoginPassword)
        bLogin = findViewById(R.id.bLogin)
        linkToRegister = findViewById(R.id.linkToRegister)
    }

    private fun setupListener() {
        bLogin.setOnClickListener {
            val email = etEmail.text.toString()
            val password = etPassword.text.toString()

            if (email.isEmpty() || password.isEmpty()) {
                Toast.makeText(this@LoginScreen, "Please fill all fields!", Toast.LENGTH_SHORT).show()
            } else {
                loginUser(email, password)
            }
        }

        linkToRegister.setOnClickListener {
            Intent(this@LoginScreen, RegisterScreen::class.java).also {
                startActivity(it)
            }
        }
    }

    private fun saveLoggedUserData(user: User) {
        val sessionManager = SessionManager(applicationContext)

        sessionManager.saveLoggedUser(
            user = user
        )
    }

    private fun loginUser(email: String, password: String) {
        thread {
            bLogin.isEnabled = false
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

                    saveLoggedUserData(
                        user = loggedUser
                    )

                    runOnUiThread {
                        Intent(this@LoginScreen, ContainerActivity::class.java).also {
                            it.putExtra("USER", loggedUser)
                            startActivity(it)
                        }

                        Toast.makeText(this@LoginScreen, "Success Login", Toast.LENGTH_SHORT).show()
                        finish()

                        bLogin.isEnabled = true
                    }
                }
            } catch (e: Exception) {
                e.printStackTrace()

                bLogin.isEnabled = true
            }
        }
    }

}