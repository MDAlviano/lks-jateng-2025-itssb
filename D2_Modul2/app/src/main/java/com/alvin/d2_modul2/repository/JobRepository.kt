package com.alvin.d2_modul2.repository

import com.alvin.d2_modul2.http.HttpHandler
import com.alvin.d2_modul2.model.Job
import com.alvin.d2_modul2.util.JsonParser
import org.json.JSONObject

object JobRepository {

    private val jsonParser = JsonParser()

    fun applyJob(jobId: Int): String {
        return HttpHandler.postRequest(
            endpoint = "api/jobs/$jobId/apply"
        )
    }

    fun getJobs(endpoint: String): List<Job> {
        val jobs = mutableListOf<Job>()
        val response = HttpHandler.getRequest(
            endpoint = endpoint
        )

        try {
            val jsonObject = JSONObject(response)
            val data = jsonObject.getJSONArray("data")
            jsonParser.parseJobFromJson(
                jobs = jobs,
                jsonArray = data
            )
        } catch (e: Exception) {
            e.printStackTrace()
        }
        return jobs
    }

}