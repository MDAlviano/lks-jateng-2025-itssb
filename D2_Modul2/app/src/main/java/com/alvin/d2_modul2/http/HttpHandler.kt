package com.alvin.d2_modul2.http

import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

object HttpHandler {

    private const val BASE_URL = "http://localhost:5000"

    fun postRequest(endpoint: String, requestBody: JSONObject? = null): String {
        val url = URL("$BASE_URL/$endpoint")
        val connection = url.openConnection() as HttpURLConnection
        return try {
            connection.requestMethod = "POST"
            connection.setRequestProperty("Content-Type", "application/json")
            connection.doOutput = true

            requestBody?.let {
                val outputStream = connection.outputStream
                outputStream.write(requestBody.toString().toByteArray())
                outputStream.flush()
                outputStream.close()
            }

            if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                connection.inputStream.bufferedReader().use { it.readText() }
            } else {
                connection.errorStream?.bufferedReader().use { it?.readText() } ?: "Error: ${connection.responseCode}, ${connection.responseMessage}"
            }

        } catch (e: Exception) {
            "Error: $e"
        }
    }

    fun getRequest(endpoint: String, token: String? = null): String {
        val url = URL("$BASE_URL/$endpoint")
        val connection = url.openConnection() as HttpURLConnection
        return try {
            connection.requestMethod = "GET"
            connection.setRequestProperty("Content-Type", "application/json")
            connection.doOutput = true

            token?.let {
                connection.setRequestProperty("Authorization", "Bearer $token")
            }

            if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                connection.inputStream.bufferedReader().use { it.readText() }
            } else {
                connection.errorStream?.bufferedReader().use { it?.readText() } ?: "Error: ${connection.responseCode}, ${connection.responseMessage}"
            }

        } catch (e: Exception) {
            "Error: $e"
        }
    }

}