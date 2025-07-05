package com.alvin.d2_modul2.repository

import com.alvin.d2_modul2.network.ApiClient
import org.json.JSONObject

object AuthRepository {

    fun login(email: String, password: String): String {
        val requestBody = JSONObject().apply {
            put("email", email)
            put("password", password)
        }

        return ApiClient.post(
            endpoint = "api/auth",
            requestBody = requestBody
        )
    }

    fun register(fullName: String, email: String, phoneNumber: String, password: String, confirmPassword: String): String {
        val requestBody = JSONObject().apply {
            put("fullName", fullName)
            put("email", email)
            put("phoneNumber", phoneNumber)
            put("password", password)
            put("confirmPassword", confirmPassword)
        }

        return ApiClient.post(
            endpoint = "api/auth",
            requestBody = requestBody
        )
    }

}