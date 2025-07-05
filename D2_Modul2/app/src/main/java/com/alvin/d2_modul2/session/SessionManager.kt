package com.alvin.d2_modul2.session

import android.content.Context
import android.content.SharedPreferences
import com.alvin.d2_modul2.util.Constants
import com.alvin.d2_modul2.model.User
import org.json.JSONObject

class SessionManager(context: Context) {

    private val PRIVATE_MODE = Context.MODE_PRIVATE

    private val prefs: SharedPreferences = context.getSharedPreferences(Constants.PREF_NAME, PRIVATE_MODE)
    private val editor: SharedPreferences.Editor = prefs.edit()

    fun saveAuthToken(token: String) {
        editor.putString(Constants.KEY_AUTH_TOKEN, token)
        editor.apply()
    }

    fun fetchAuthUser(): String? {
        return prefs.getString(Constants.KEY_AUTH_TOKEN, null)
    }

    fun saveLoggedUser(user: User) {
        val userJsonObject = JSONObject().apply {
            put("id", user.id)
            put("profilePicture", user.pictureUri)
            put("fullname", user.fullName)
            put("email", user.email)
            put("phoneNumber", user.phoneNumber)
            put("role", user.role)
        }
        editor.putString(Constants.KEY_LOGGED_USER, userJsonObject.toString())
        editor.apply()
    }

    fun fetchLoggedUser(): User? {
        val userJsonString = prefs.getString(Constants.KEY_LOGGED_USER, null)
        return if (userJsonString != null) {
            try {
                val userJsonObject = JSONObject(userJsonString)
                User(
                    id = userJsonObject.getInt("id"),
                    pictureUri = userJsonObject.getString("profilePicture"),
                    fullName = userJsonObject.getString("fullname"),
                    email = userJsonObject.getString("email"),
                    phoneNumber = userJsonObject.getString("phoneNumber"),
                    role = userJsonObject.getString("role")
                )
            } catch (e: Exception) {
                e.printStackTrace()
                null
            }
        } else {
            null
        }
    }

}